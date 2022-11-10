using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.Translate(new Vector2(speed * Input.GetAxisRaw("Horizontal")*Time.deltaTime, 0),Space.World);
    }
}
