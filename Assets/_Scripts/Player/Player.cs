using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private GameObject friendlyBullet;
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private Transform bulletExitPos;
    [SerializeField] private ObjectPool pool = null;
    
    [Header("Variables")]
    [SerializeField] private float fireWaitTime;
    [SerializeField] private float speed;
    [SerializeField] private float moveRange;
   
    private bool isShooting;

    
    
    
    
    private void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        var horizontalInput = joystick.Horizontal;
        
        StayInGameArea();
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
    }

    private void StayInGameArea()
    {
        if (transform.position.x > moveRange)
        {
            transform.position = new Vector2(moveRange, transform.position.y);
        }
        else if (transform.position.x < -moveRange)
        {
            transform.position = new Vector2(-moveRange, transform.position.y);
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isShooting)
        {
            StartCoroutine(ShootInterval());
        }
    }
    private IEnumerator ShootInterval()
    {
        isShooting = true;
        GameObject obj = pool.GetPooledObject();
        obj.transform.position = bulletExitPos.position;
        yield return new WaitForSeconds(fireWaitTime);
        isShooting = false;
    }
}
