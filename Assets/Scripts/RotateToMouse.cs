using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    private Camera cam;
    [Header("Float - maximum range of camera to trigger  ")] public float maxLength;

    private Ray rayMouse;
    private Vector3 direction;
    private Quaternion rotation;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if (cam != null)
        {
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            rayMouse = cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maxLength))
            {
                RotateToMouseDirection(gameObject, hit.point);
            }
            else
            {
                var pos = rayMouse.GetPoint(maxLength);
                RotateToMouseDirection(gameObject, pos);
            }
        }
        else
            Debug.Log("No Camera!");


        // 限制物体，只在 Y 轴上的旋转
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);


    }

    void RotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);

    }

    public Quaternion GetRotation()
    {
        // Debug.Log("ddddddddddd4" + rotation);
        return rotation;
    }
}
