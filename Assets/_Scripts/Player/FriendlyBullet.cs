using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBullet : MonoBehaviour
{
    [SerializeField] private float speed;


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    
}
