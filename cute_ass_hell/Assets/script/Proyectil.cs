﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    //velocitat del proyectil
    public float speed;
    //temps abans que s'elimini el proyectil.
    public float timeToDelete;
    //direccio en la que es moura el proyectil.
    public Vector3 direction;
    float actualTime;

    // Start is called before the first frame update
    void Start()
    {
        actualTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    { 
        //en cada update es mou en la direccio marcada al crear el proyectil.
        Moviment.Moures(direction.x * 10, direction.y * 10, speed, this.gameObject);

        //si el temps limit s'acaba s'elimina el proyectil.
        if (actualTime + (timeToDelete * Time.deltaTime) < Time.time)
        {
            Destroy(this.gameObject);
        }  
    }

    //si el proyectil choca contra un objecte que no sigui el jugador o un altre proyectil s'elimina.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.CompareTag("Player") || collision.CompareTag("ProyectilPlayer")))
        {
            Destroy(this.gameObject);

            Debug.Log("colision with " + collision.name);
        }
    }
}
