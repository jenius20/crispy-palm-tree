using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateNormal : MonoBehaviour {

    void FixedUpdate()
    {
        RaycastHit hit;


        //cast a ray down in the world from our current position
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            //sets the rotation so the x-axis aligns to the normal of the surface beneath us
            //this aligns the x to the surface's outward direction not the surface's x-axis
            transform.rotation = Quaternion.FromToRotation(Vector3.right, hit.normal);

        }

    }
}
