using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterSecond : MonoBehaviour
{
    [SerializeField] private float upLimit;

    private void Update()
    {
        DisableObject();
    }

    private void DisableObject()
    {
        if (transform.position.y > upLimit)
        {
            gameObject.SetActive(false);
        }
    }
}
