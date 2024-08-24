using UnityEngine;
using System.Collections;

//generic plataform controler(like megaman, mario...)


public class MegamanControler : MonoBehaviour {


    [Header("Moviment")]
    public float pixelToUnit = 40f;
    public float maxVelocity = 10f; // pixels per second
    public Vector3 moveSpeed = Vector3.zero;//(0,0,0)

    [Header("Animation")]
    public bool isFacingLeft = false;
    public bool isRunning = false;

    [Header("Components")]
    public Rigidbody2D rigidbody2d;
    public SpriteRenderer spriterenderer;

    // Use this for initialization
    void Start () {

        rigidbody2d = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
	}
	// Update is called once per frame - EveryTick
	void Update () {
        UpdateAnimatorParameters ();
        HandleHorizontalParameters ();
        HandleVerticalParameters ();
        MoveCharacterControllers ();
	}
      
    void HandleHorizontalParameters() {
        moveSpeed.x = Input.GetAxis ("Horizontal") * (maxVelocity / pixelToUnit);

        if (Input.GetAxis("Horizontal") < 0 && !isFacingLeft)
        {
            //muda o megaman para a esquerda
            isFacingLeft = true;
        }
        else if (Input.GetAxis("Horizontal") > 0 && isFacingLeft)
        {
            //muda o megaman para a direita
            isFacingLeft = false;
        }
        
        spriterenderer.flipX = isFacingLeft;
    }
    
    //jump
    void HandleVerticalParameters() {
        moveSpeed.y = Input.GetAxis("Vertical") * 10f;
    }

    
    void MoveCharacterControllers() {
        rigidbody2d.velocity = moveSpeed;
    }

    

}
