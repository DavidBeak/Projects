using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using System.Linq;

public class MoveLoptica : MonoBehaviour { 
    public Rigidbody2D rigidbody = new Rigidbody2D();
    public GameObject text;
    public float brojac = 0;
    public float constantSpeed;
    public float Koliko = 4;
    public Sprite Sprite;
    GameObject[] jk;
    void Start() { 
    jk = new GameObject[(int)Koliko];
    }
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

        if (GameObject.Find("Alo") == null) Spawn(ref Koliko,ref jk,Sprite);

           rigidbody.gravityScale = 0;
        }
        //Udarac loptice u metu
        if (collision.collider.tag == "Bam"){

            Destroy(collision.collider.gameObject);
            brojac++;
            //Debug.Log(brojac);
            text.GetComponent<TextMeshPro>().text = brojac.ToString();
        }
    
    }
   //Novi nivo
    public void Spawn(ref float Koliko,ref GameObject[] jk, Sprite Sprite)
    {
         int aloevera = 0;
        System.Random r = new System.Random();
        for (int i = 0; i < Koliko; i++)
        {
           if (aloevera > Koliko * 2) break;
            GameObject a = new GameObject("Alo", typeof(BoxCollider2D), typeof(SpriteRenderer));
            a.GetComponent<Transform>().localPosition = new Vector2((float)(r.NextDouble() * (10.107 + 10.107) - 10.107), (float)(r.NextDouble() * (4.5 - 0.5) + 0.5));
            if (Provera(a, jk, i)) {
                Destroy(a);
                i--;
                continue;
            }
            jk[i] = a;
            a.GetComponent<SpriteRenderer>().sprite = Sprite;
            a.tag = "Bam";
        }
        Koliko++;
        jk = new GameObject[(int)Koliko];
    }
   static bool Provera(GameObject a, GameObject[] jk, int i) {
        bool l = false;
        for (int j = 0; j < i; j++)
        {
            if (System.Math.Abs(a.transform.position.x - jk[j].transform.position.x) < 1.5f && System.Math.Abs(a.transform.position.y - jk[j].transform.position.y) < 1.5f)
            {
                l = true;
            }
        }
        return l;
    }
}
