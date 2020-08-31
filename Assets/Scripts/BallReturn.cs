using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour
{
   private BallLauncher ballLauncher;

   private void Awake()
   {
      ballLauncher = FindObjectOfType<BallLauncher>();
   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
      collision.gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
      ballLauncher.ReturnBall();
      collision.collider.gameObject.SetActive(false); 
   }
}
