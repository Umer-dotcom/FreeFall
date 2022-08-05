using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public static DragController instance;

    private bool _isDragActive = false;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private Draggable _lastDragged;

    [SerializeField] private bool _thereIsLimit;

    [SerializeField] private bool xLock;
    [SerializeField] private Vector2 xLim;

    [SerializeField] private bool yLock;
    [SerializeField] private Vector2 yLim;

    [SerializeField] private GameObject selectedObj;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Update()
    {
        if(_isDragActive && (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop();
            return;
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if(Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if(_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if(hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if(draggable != null)
                {
                    if(draggable.gameObject.CompareTag("Platform"))
                    {
                        GameObject parent = draggable.transform.parent.gameObject;
                        LineRenderer line = transform.Find("LineRenderer").GetComponent<LineRenderer>();
                        // line.colorGradient.alphaKeys = 
                    }

                    selectedObj = hit.transform.gameObject;
                    xLock = selectedObj.GetComponent<LockAxis>().xAxis;
                    yLock = selectedObj.GetComponent<LockAxis>().yAxis;

                    CheckIfAnyLimit();

                    _lastDragged = draggable;
                    InitiDrag();
                }
            }
        }
    }

    private void InitiDrag()
    {
        _isDragActive = true;
    }

    private void Drag()
    {
        if(xLock && yLock)
        {
            // No movement if both axis are locked
            Debug.Log("Both axis are locked!");
        }
        else if(xLock)
        {
            Debug.Log("X axis is locked");
            if(_thereIsLimit)
            {
                _lastDragged.transform.position = new Vector2(selectedObj.transform.position.x, _worldPosition.y);
                if(_lastDragged.transform.position.y >= yLim.y)
                {
                    _lastDragged.transform.position = new Vector2(selectedObj.transform.position.x, yLim.y);
                }
                else if(_lastDragged.transform.position.y <= yLim.x)
                {
                    _lastDragged.transform.position = new Vector2(selectedObj.transform.position.x, yLim.x);
                }
            }
        }
        else if(yLock)
        {
            Debug.Log("Y axis is locked");
            if (_thereIsLimit)
            {
                _lastDragged.transform.position = new Vector2(_worldPosition.x, selectedObj.transform.position.y);
                if (_lastDragged.transform.position.x >= xLim.y)
                {
                    _lastDragged.transform.position = new Vector2(xLim.y, selectedObj.transform.position.y);
                }
                else if (_lastDragged.transform.position.x <= xLim.x)
                {
                    _lastDragged.transform.position = new Vector2(xLim.x, selectedObj.transform.position.y);
                }
            }
        }
        else
        {
            Debug.Log("No axis is locked");
            _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
        }
    }

    private void Drop()
    {
        _isDragActive = false;
        _thereIsLimit = false;
        xLock = false;
        yLock = false;
        xLim = Vector2.zero;
        yLim = Vector2.zero;
        selectedObj = null;
    }

    private void CheckIfAnyLimit()
    {
        if(selectedObj)
        {
            if(selectedObj.GetComponent<LockAxis>()._isAnyLimit == true)
            {
                Debug.Log("There is a limit!");
                _thereIsLimit = true;
                xLim = new Vector2(selectedObj.GetComponent<LockAxis>().xAxisLimit.x, selectedObj.GetComponent<LockAxis>().xAxisLimit.y);
                yLim = new Vector2(selectedObj.GetComponent<LockAxis>().yAxisLimit.x, selectedObj.GetComponent<LockAxis>().yAxisLimit.y);
            }
        }
    }
}
