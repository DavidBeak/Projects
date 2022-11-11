using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    float Koliko = 4;
    [SerializeField]
    Sprite Sprite;
    float brojac = 0;
    void Start()
    {
        System.Random r = new System.Random();
        for (int i = 0; i < Koliko; i++)
        {
            GameObject a = new GameObject("Alo", typeof(BoxCollider2D), typeof(SpriteRenderer));
            a.GetComponent<SpriteRenderer>().sprite = Sprite;
            a.GetComponent<Transform>().localPosition = new Vector2((float)(r.NextDouble() * (10.107 + 10.107) - 10.107), (float)(r.NextDouble() * (4.5 - 0.5) + 0.5));
            a.tag = "Bam";
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bam") {
            brojac++;
            Debug.Log(brojac);
        }
    }


}
