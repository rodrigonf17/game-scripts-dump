using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdController : MonoBehaviour {

	[Header("Velocity")]//forma de declarar um titulo para a interface Inspector
	public float flappyVelocity;//variavel flutuante da velocidade

	[Header("FlappyBird states")]
	public bool isDead = false;

	private Animator animator;
	private Rigidbody2D rigidBody2d;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rigidBody2d = GetComponent<Rigidbody2D> ();

		// Convertendo de coordenadas de Tela para Mundo
		Vector3 startPos = 
			Camera.main.ViewportToWorldPoint (new Vector3 (0.2f, 0.8f));

		startPos.z = -1.58f; // Para garantir visibilidade do FlappyBird

		transform.position = startPos;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead)
			return;


		if (Input.GetKeyDown (KeyCode.Space)) {
			FlappyWings ();
		}

		Vector3 angles = transform.eulerAngles;
		angles.z = Mathf.Clamp (rigidBody2d.velocity.y * 4f, -90f, 45f);
		transform.eulerAngles = angles;
	}

	// Faz o FlappyBird bater asas
	void FlappyWings() {
		// Anima o FlappyBird
		animator.SetTrigger ("Flappy");
		// Movimenta o FlappyBird
		rigidBody2d.velocity = Vector2.up * flappyVelocity;

	}

	void OnCollisionEnter2D(Collision2D collision) {
		// Se for pipe entao mata o FlappyBird

		if (collision.collider.CompareTag ("Pipe")) {
			// Mooorreu :(
			isDead = true;
			// Deixa de colidir
			GetComponent<Collider2D> ().isTrigger = true;
		}
	}
}
