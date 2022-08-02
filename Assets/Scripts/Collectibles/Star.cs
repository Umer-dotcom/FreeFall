using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private ParticleSystem starCollectionEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            AudioManager.instance.Play("Star");
            this.gameObject.SetActive(false);
            starCollectionEffect.transform.position = transform.position;
            starCollectionEffect.Play();
        }
    }
}
