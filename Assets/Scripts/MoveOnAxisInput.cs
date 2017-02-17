using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnAxisInput : MonoBehaviour
{

    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public float speed = 1.0f;
    public LayerMask layerMask = -1;

	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        Vector3 moveDirection = (Vector3.right * Input.GetAxis(horizontalAxis) + Vector3.forward * Input.GetAxis(verticalAxis)).normalized * speed * Time.deltaTime;

        RaycastHit hit;
        if(Physics.Raycast(transform.position, moveDirection,out hit, 1.0f,layerMask))
        {
            Vector3 tangent = Vector3.Cross(Vector3.Cross(hit.normal, moveDirection), hit.normal).normalized;
            if (!Physics.Raycast(transform.position, tangent, 1.0f,layerMask))
            {
                transform.position += tangent * speed * Time.deltaTime;
            }

        }
        else
        {
            transform.position += moveDirection;
        }

	}
}
