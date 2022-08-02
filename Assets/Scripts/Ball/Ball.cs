using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private ParticleSystem HitEffectPS;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.GetContact(0).point);
        if(HitEffectPS)
        {
            Debug.Log("Gonna play the animation!");
            HitEffectPS.transform.position = collision.GetContact(0).point;
            HitEffectPS.Play();
        }
    }
}
