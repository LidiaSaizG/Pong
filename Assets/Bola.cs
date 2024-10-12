using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;
    public AudioClip cling;  


    private Rigidbody2D ballRb;
    
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        Launch();
        cling = (AudioClip)Resources.Load("Audio/cling");
    }

    private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pala"))
        {
            ballRb.velocity *= velocityMultiplier;
            AudioSource.PlayClipAtPoint(cling, transform.position);
        }       
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Gol1"))
        {
            GameManager.Instance.jugador2Puntua();
            GameManager.Instance.Restart();
            Launch();
        }
        else
        {
            GameManager.Instance.jugador1Puntua();
            GameManager.Instance.Restart();
            Launch();
        }

    }

   

   
}
