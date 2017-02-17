using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnAxisInput : MonoBehaviour
{
    public Rigidbody rb;

    public float floatDistance = 1.0f;
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public float speed = 1.0f;
    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;
    public float rotSpeed = 1.0f;
    public Transform myCameraTransform;
    private Vector3 lookDirection;
    private Vector3 normal;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_Cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        m_Move = (v * transform.forward);



    }
    private void FixedUpdate()
    {



        RaycastHit hit;
        Physics.Raycast(transform.position+new Vector3(0.0f,0.5f,0.0f), -transform.up, out hit);
        if (Physics.Raycast(transform.position + new Vector3(0.0f, 0.5f, 0.0f), -transform.up, 2))
        {

            normal = hit.normal;

            transform.up = normal;
        }
        if (hit.distance > floatDistance)
        {
            rb.AddForce(-transform.up * 50);
        }


        m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;

        lookDirection = Vector3.ProjectOnPlane(m_CamForward,normal);
        Debug.DrawRay(hit.point, lookDirection);
        transform.forward = lookDirection;
       // transform.up = normal;


        rb.MovePosition(transform.position + m_Move*speed*Time.deltaTime);
        

    }
}
