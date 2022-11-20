using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pwup : MonoBehaviour
{
    private void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = 3 * (gameObject.GetComponent<Rigidbody2D>().velocity.normalized);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            Destroy(gameObject);
            
        
        }
    }
}
