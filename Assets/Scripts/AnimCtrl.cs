using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCtrl : MonoBehaviour
{

    [Header("Float - Speed of Player")] public float playerMoveSpeed;

    private Animator ator;

    void Start()
    {
        ator = GameObject.FindGameObjectWithTag("OBJ_Player").GetComponent<Animator>();
        if (ator == null)
            Debug.Log("Error to get OBJ_Player's Animator!");
    }

    void FixedUpdate()
    {
        // //行走动画控制
        // if (Input.GetKey("w"))
        // {
        //     ator.SetBool("isWalking", true);

        //     transform.position += transform.forward * (playerMoveSpeed * Time.deltaTime);

        //     //ator.SetFloat(Animator.StringToHash("speedBlend"), playerMoveSpeed);

        // }
        // if (!Input.GetKey("w"))
        // {
        //     ator.SetBool("isWalking", false);

        // }
    }

    public Animator GetAnimCtrl()
    {
        ator = GameObject.FindGameObjectWithTag("OBJ_Player").GetComponent<Animator>();
        if (ator == null)
            Debug.Log("AnimCtrl Return NO ATOR!!!");
        return ator;
    }


    // public void Test()
    // {
    //     Debug.Log("TEST___");
    // }

}
