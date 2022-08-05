using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopController : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private bool isItGoal;
    [SerializeField] private bool isItFoul;

    private void Awake()
    {
        if (anim == null)
            anim = GetComponent<Animator>();

        isItGoal = false;
        isItFoul = false;
    }

    private void Update()
    {
        if (isItFoul && isItGoal)
        {
            Debug.Log("GOAL & FOUL GOAL CANCELLED EACH OTHER!");
            isItGoal = false;
            isItFoul = false;
        }
        else if (isItGoal)
        {
            Debug.Log("Goal!!!");
            GameManager.instance.GoalIsMade();
        }
    }

    public void Shake()
    {
        anim.SetTrigger("Shake");
        AudioManager.instance.Play("Ring");
    }

    public void Goal()
    {
        Debug.Log("GOAL!");
        isItGoal = true;
    }

    public void FalseGoal()
    {
        Debug.Log("False Goal!");
        isItFoul = !isItFoul;
    }

    public void ResetValues()
    {
        isItGoal = false;
        isItFoul = false;
    }
}
