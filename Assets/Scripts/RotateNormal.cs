using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateNormal : MonoBehaviour {
    private Vector3 hitr;

    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit);
        if (Physics.Raycast(transform.position, Vector3.down, 2))
        {
            transform.up = hit.normal;
        }
    }
}
