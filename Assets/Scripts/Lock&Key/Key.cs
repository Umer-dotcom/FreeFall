using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private Vector2 currPos;

    private void Awake()
    {
        currPos = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x, currPos.y);
    }
}
