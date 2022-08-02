using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAxis : MonoBehaviour
{
    [SerializeField] public bool yAxis;
    [SerializeField] public bool xAxis;

    [SerializeField] public bool _isAnyLimit;
    [SerializeField] public Vector2 xAxisLimit;
    [SerializeField] public Vector2 yAxisLimit;
}
