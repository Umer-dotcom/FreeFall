using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform wayPoint1;
    [SerializeField] private Transform wayPoint2;

    [SerializeField] private bool xAxis;
    [SerializeField] private bool yAxis;

    private void Awake()
    {
        xAxis = this.GetComponent<LockAxis>().xAxis;
        yAxis = this.GetComponent<LockAxis>().yAxis;
    }

    private void Start()
    {
        if(xAxis)
        {
            // Movement on Y Axis
            this.GetComponent<LockAxis>().yAxisLimit.x = wayPoint1.position.y;
            this.GetComponent<LockAxis>().yAxisLimit.y = wayPoint2.position.y;

        }
        else if(yAxis)
        {
            // Movement on X Axis
            this.GetComponent<LockAxis>().xAxisLimit.x = wayPoint1.position.x;
            this.GetComponent<LockAxis>().xAxisLimit.y = wayPoint2.position.x;
        }
    }
}
