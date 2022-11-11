using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLoptica : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    float y = 0;
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
        if (collision.collider.tag != "Nepomerljiv") rigidbody.gravityScale = 0;
    }
}
