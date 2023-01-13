using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    private Vector3 direction;
    private Quaternion rotation;

    Animator ator;

    void Start()
    {
        // ator = GameObject.FindGameObjectWithTag("OBJ_Player").GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        Vector3 direction2 = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        // rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (direction2 != new Vector3(0, 0, 0)) //important!!
        {
            transform.position += direction2 * (speed * Time.deltaTime);
            ator = GameObject.FindGameObjectWithTag("OBJ_Player").GetComponent<Animator>();
            if (ator == null) Debug.Log("Error to get OBJ_Player's Animator!");

            ator.SetBool("isWalking", true);
            GameObject.FindGameObjectWithTag("OBJ_Player").transform.LookAt(direction2 * 100);

        }
        if (direction2 == new Vector3(0, 0, 0))
        {
            ator = GameObject.FindGameObjectWithTag("OBJ_Player").GetComponent<Animator>();
            if (ator == null) Debug.Log("Error to get OBJ_Player's Animator!");

            ator.SetBool("isWalking", false);
        }

    }

    void Update()
    {
        
    }


    void RotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);

    }
}