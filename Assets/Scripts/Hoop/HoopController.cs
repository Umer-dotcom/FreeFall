using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopController : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void Awake()
    {
        if (anim == null)
            anim = GetComponent<Animator>();
    }

    public void Shake()
    {
        anim.SetTrigger("Shake");
    }
}
