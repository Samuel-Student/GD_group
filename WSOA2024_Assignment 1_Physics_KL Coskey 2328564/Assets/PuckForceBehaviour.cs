using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckForceBehaviour : MonoBehaviour
{
    public float bounce = 3.0f;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Vector2 ogDir = transform.GetComponent<Rigidbody2D>().velocity.normalized;
            Vector3 ogVel = transform.GetComponent<Rigidbody2D>().velocity;
            //Debug.Log(transform.GetComponent<Rigidbody2D>().velocity);
            ogDir.x = ogDir.x*2;


            //transform.GetComponent<Rigidbody2D>().velocity = ogDir* ogMag;
            transform.GetComponent<Rigidbody2D>().AddForce(collision.contacts[0].normal , ForceMode2D.Impulse);
            Debug.Log(transform.GetComponent<Rigidbody2D>().velocity);
        }
        else
        {
            transform.GetComponent<Rigidbody2D>().AddForce(collision.contacts[0].normal , ForceMode2D.Impulse);
        }
        transform.GetComponent<Rigidbody2D>().AddForce(collision.contacts[0].normal , ForceMode2D.Impulse);
    }
}