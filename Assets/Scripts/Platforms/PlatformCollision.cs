using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(anim != null)
        {
            if(collision.collider.CompareTag("Ball"))
            {
                anim.SetTrigger("Scale");
            }
        }
    }
}
