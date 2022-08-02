using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private Vector2 currPos;
    [SerializeField] private float Threshold;
    [SerializeField] private float keyMoveSpeed;
    [SerializeField] private float factorToMoveKeyBack;

    [SerializeField] private float animPlayThreshold;

    private bool rightKey;

    private void Awake()
    {
        currPos = transform.position;
        animPlayThreshold = currPos.x - Threshold;
        this.GetComponent<LockAxis>().xAxisLimit.y = currPos.x;
        this.GetComponent<LockAxis>().xAxisLimit.x = currPos.x - factorToMoveKeyBack;

        // For Right Key
        if(currPos.x < currPos.x - factorToMoveKeyBack)
        {
            rightKey = true;
            this.GetComponent<LockAxis>().xAxisLimit.y = currPos.x - factorToMoveKeyBack;
            this.GetComponent<LockAxis>().xAxisLimit.x = currPos.x;
        }
    }

    private void Update()
    {
        if (rightKey)
        {
            if(transform.position.x >= animPlayThreshold)
            {
                if (transform.position.x < this.GetComponent<LockAxis>().xAxisLimit.y)
                {
                    Debug.Log("playing animation");
                    transform.position = Vector2.Lerp(transform.position, new Vector2(this.GetComponent<LockAxis>().xAxisLimit.y, currPos.y), Time.deltaTime * keyMoveSpeed);
                }
                else
                {
                    Debug.Log("I am done with animation");
                    this.GetComponent<Draggable>().enabled = false;
                }
            } 
        }
        if (transform.position.x <= animPlayThreshold)
        {
            // Play Animation
            if (transform.position.x > this.GetComponent<LockAxis>().xAxisLimit.x)
            {
                Debug.Log("playing animation");
                transform.position = Vector2.Lerp(transform.position, new Vector2(this.GetComponent<LockAxis>().xAxisLimit.x, currPos.y), Time.deltaTime * keyMoveSpeed);
            }
            else
            {
                Debug.Log("I am done with animation");
                this.GetComponent<Draggable>().enabled = false;
            }
        }
    }
}
