using System;
using System.Collections.Generic;
using UnityEngine;

public class hoverScript : MonoBehaviour
{

    public Material transparent, solid;
   
    Vector3 dist;
    float posX, posY;
    public bool drag = true;
    bool snap = false;

    public bool Snap
    {
        get
        {
            return snap;
        }

        set
        {
            snap = value;
        }
    }

    private void Start()
    {
        // Find current position
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;

    }
    void Update()
    {
        if (drag)
        {
            // Given current position and user is dragging, update position according to mouse movement
            Vector3 currentPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(currentPos);

            transform.position = worldPos;
        }
    }
    public void StartDragging()
    {
        // Start dragging if the mouse did not snap to a snap point
        if (!Snap && !drag) drag = true;
    }

    public void EndDragging(Vector3 NewPosition)
    {
        // Stop dragging if the mouse reached into a snap point
        if (drag) drag = false;
        transform.position = new Vector3(NewPosition.x, NewPosition.y - 0.3f, NewPosition.z);
    }

    public void SnapToObject()
    {
        Snap = true;
        // Change shader and snap
        GetComponent<Renderer>().material = solid;
    }
}