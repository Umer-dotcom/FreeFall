using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private ParticleSystem HitEffectPS;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(HitEffectPS)
        {
            HitEffectPS.transform.position = collision.GetContact(0).point;
            AudioManager.instance.Play("Basketball");
            HitEffectPS.Play();
        }
    }
}
