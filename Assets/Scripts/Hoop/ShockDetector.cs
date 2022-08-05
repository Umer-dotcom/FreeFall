using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockDetector : MonoBehaviour
{
    [SerializeField] private HoopController controller;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ball"))
        {
            if (controller)
                controller.Shake();
        }
    }
}
