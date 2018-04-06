using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snap : MonoBehaviour {

    
    public GameObject hover;
    public GameObject[] SnapPoints;
    hoverScript h;
    public bool didSpawn = false;
    private bool didSpawnHover = false;

    // Update is called once per frame
    void Update () {
        RaycastHit hit;

        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Does the ray intersect any objects excluding the player layer
        
        if (Physics.Raycast(r, out hit, 100.0f))
        {

            foreach (GameObject sp in SnapPoints)
            {

                if (hit.collider.name.Equals(sp.name) && didSpawn)
                {
                    // Mouse is hovering over a snap point && a hovering object is spawned
                    // Snap hovering object to snap point
                    h.EndDragging(sp.transform.position);

                    if (Input.GetMouseButtonDown(0))
                    {
                        h.SnapToObject();
                        didSpawn = false;
                    }
                }

            }

        }
        else
        {
            // Did not hit any object
            if (!h.Snap)
            {
                h.StartDragging();
            }
        }
    }
    
    public void SpawnHover()
    {
        if (!didSpawnHover)
        {
            GameObject hs = GameObject.Instantiate(hover, new Vector3(transform.localPosition.x, transform.localPosition.y + 1.2f, transform.localPosition.z + 4.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            didSpawn = true;
            h = hs.GetComponent<hoverScript>();
            didSpawnHover = true;
        }
    }
    
}
