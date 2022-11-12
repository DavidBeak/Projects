using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class MoveLoptica : MonoBehaviour
{
    public Rigidbody2D rigidbody = new Rigidbody2D();
    public GameObject text;
    public float brojac = 0;
    public float constantSpeed;
    public float Koliko = 4;
    public Sprite Sprite;

    void Update()
    {
        rigidbody.velocity = constantSpeed * (rigidbody.velocity.normalized);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Udarac loptice u zemlju
        if (collision.collider.tag == "Smrt") Destroy(rigidbody.gameObject);
        //Udarac loptice u igraca
        if (collision.collider.tag != "Nepomerljiv") {

        if (GameObject.Find("Alo") == null) Spawn(ref Koliko,Sprite);

           rigidbody.gravityScale = 0;
        }
        //Udarac loptice u metu
        if (collision.collider.tag == "Bam"){

            Destroy(collision.collider.gameObject);
            brojac++;
            Debug.Log(brojac);
       //     text.GetComponent<TextMeshPro>().text = brojac.ToString();
     
        }
    
    }
   //Novi nivo
    public void Spawn(ref float Koliko, Sprite Sprite)
    {
        System.Random r = new System.Random();
        for (int i = 0; i < Koliko; i++)
        {
            GameObject a = new GameObject("Alo", typeof(BoxCollider2D), typeof(SpriteRenderer));
            a.GetComponent<SpriteRenderer>().sprite = Sprite;
            a.GetComponent<Transform>().localPosition = new Vector2((float)(r.NextDouble() * (10.107 + 10.107) - 10.107), (float)(r.NextDouble() * (4.5 - 0.5) + 0.5));
            a.tag = "Bam";
        }
        Koliko++;
    }
}
