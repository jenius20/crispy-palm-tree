using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;

    private float inputH;
    private float inputV;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("1"))
        {
            int n = Random.Range(0, 3);
            if(n == 0)
            {
                anim.Play("AntDeath0", -1, 0f);
            }

            if(n == 1)
            {
                anim.Play("AntDeath01", -1, 0f);
            }
            if (n == 2)
            {
                anim.Play("AntDeath02", -1, 0f);
            }

        }

        
        if (Input.GetKeyDown("2"))
        {
            anim.Play("AntHurt", -1, 0f);
        }
        if (Input.GetKeyDown("3"))
        {
            anim.Play("AntAttack0", -1, 0f);
        }
        if (Input.GetKeyDown("4"))
        {
            anim.Play("AntAttack01", -1, 0f);
        }
        if (Input.GetKeyDown("5"))
        {
            anim.Play("AntAttack02", -1, 0f);
        }
        if (Input.GetKeyDown("6"))
        {
            anim.Play("AntWalk", -1, 0f);
        }

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
    }
}
