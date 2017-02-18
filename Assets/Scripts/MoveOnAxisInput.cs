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
    public float damping = 1.0f;
    private float angle;
    private Vector3 normalForward;

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

        RaycastHit hitForward;

        if(Physics.Raycast(transform.position + new Vector3(0.0f, 0.5f, 0.0f), transform.forward, out hitForward, 2))
        {
            normalForward = hitForward.normal;
        }
        Debug.DrawRay(transform.position + new Vector3(0.0f, 0.5f, 0.0f), transform.forward, Color.red);
        RaycastHit hit;

        if (Physics.Raycast(transform.position + new Vector3(0.0f, 0.5f, 0.0f), -transform.up,out hit, 2))
        {

            normal = hit.normal;

          //  transform.position = hit.point;
        }
        Debug.DrawRay(transform.position + new Vector3(0.0f, 0.5f, 0.0f), -transform.up, Color.red);
        if (hit.distance > floatDistance)
        {
            rb.AddForce(-transform.up * 500);
        }



        Debug.DrawRay(hit.point, Vector3.ProjectOnPlane(transform.right, hit.normal), Color.blue);
   /*    
        if(hitForward.distance < hit.distance)
        {
            lookDirection = Vector3.ProjectOnPlane(m_CamForward, normalForward);
            angle = Vector3.Angle(transform.right, Vector3.ProjectOnPlane(transform.right, hitForward.normal));
        }
        else
        {
            lookDirection = Vector3.ProjectOnPlane(m_CamForward, normal);
            angle = Vector3.Angle(transform.right, Vector3.ProjectOnPlane(transform.right, hit.normal));
        } */
        m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
        
        lookDirection = Vector3.ProjectOnPlane(m_CamForward,normal);
        Debug.DrawRay(hit.point, lookDirection, Color.yellow);

        transform.forward = lookDirection;
        angle = Vector3.Angle(transform.right, Vector3.ProjectOnPlane(transform.right, hit.normal));
        Debug.Log(angle);
        Debug.Log(transform.eulerAngles.y);
        if(transform.eulerAngles.y > 0.0f && transform.eulerAngles.y < 180.0f)
        {
            transform.Rotate(0, 0, -angle);
        }
        else
        {
            transform.Rotate(0, 0, angle);
        }

        rb.MovePosition(transform.position + m_Move*speed*Time.deltaTime);
        

    }
}
