using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseGoalDetector : MonoBehaviour
{
    [SerializeField] private HoopController controller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball"))
        {
            if (controller)
                controller.FalseGoal();
        }
    }
}
