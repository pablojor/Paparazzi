﻿using UnityEngine;

public class Controller : MonoBehaviour {

	public float moveSpeed = 6;
    float realSpeed;

	Rigidbody2D rb;


	Vector2 velocity;

    void Start () {
        if (GameManager.instance.MinijuegoTerminado() && GameManager.instance.NivelActual() == "Nivel1")
            transform.position = new Vector3(-16.44f, 42, 0);

        realSpeed = moveSpeed;//Guarda la velocidad para cuando se stunee
		rb = GetComponent<Rigidbody2D> ();
    }

    void Update () {

		velocity = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;//Movimiento

             



    }

    void FixedUpdate() {
		
		rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime); //Movimiento
        

	}

    public bool CompruebaE()//Comprueba si se pulsa la E
    {
        if (Input.inputString == "e")
            return true;

        else
            return false;
    }

    public void Stuned()//Para cuando se stunee al jugador
    {
        moveSpeed = 0;
        Invoke("NoStunned", 1);
    }

    void NoStunned()
    {
        moveSpeed = realSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Guardia") && collision.gameObject.transform.parent.transform.GetChild(0).GetComponent<Detect>().LeVeo())
            GameManager.instance.Pierde();
        
    }



}