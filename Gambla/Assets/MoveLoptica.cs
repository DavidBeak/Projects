using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveLoptica : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public GameObject script;
    float y = 0;
    float brojac = 0;
    float k;
    [SerializeField]
    float constantSpeed;
    void Update()
    {
        rigidbody.velocity = constantSpeed * (rigidbody.velocity.normalized);
        rigidbody.angularDrag = 0;
        rigidbody.angularVelocity = 0;
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Smrt") GameObject.Destroy(rigidbody.gameObject);
        if (collision.collider.tag != "Nepomerljiv") {
            script.SetActive(true);
            rigidbody.gravityScale = 0; 
        }
    if (collision.collider.tag == "Bam")
            {
            collision.collider.gameObject.SetActive(false); 
                brojac++;
                Debug.Log(brojac);
            }
        
    }
}
