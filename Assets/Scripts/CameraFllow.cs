using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    [Header("Prefab - Player")] public GameObject playerPrefab;


    private Transform cm_Transform;
    private Transform player_Transform;
    private Vector3 offset;



    void Start()
    {
        Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity).transform.SetParent(GameObject.FindGameObjectWithTag("OBJ_ParentPlayer").transform);

        cm_Transform = this.GetComponent<Transform>();
        player_Transform = GameObject.FindGameObjectWithTag("OBJ_Player").GetComponent<Transform>();
        offset = cm_Transform.position;//offset是摄像机相对于人物主角的相对位置


       
    }

    void Update()
    {
        //直接改变摄像机的位置（这种方式比较生硬，建议使用下一种插值的方式）
        //cm_Transform.position = player_Transform.position + offset;
        //插值的方式控制摄像机的跟随
        cm_Transform.position = Vector3.Lerp(cm_Transform.position, player_Transform.position + offset, Time.deltaTime * 2);
    }

}