using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;

    [SerializeField] private float moveSpeed = 10f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody2D.velocity = rigidbody2D.velocity.normalized * moveSpeed;
    }
}
