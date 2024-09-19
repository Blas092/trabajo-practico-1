using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador : MonoBehaviour
{
    public float movementSpeed = 1;
    public float fuerzadesalto=10;
    private Rigidbody2D rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rbody.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rbody.velocity = Vector2.up* fuerzadesalto;
        //El codigo del salto va aqui
    }
}
