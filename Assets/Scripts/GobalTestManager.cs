/// <summary>
/// 全局测试对象管理（比如：进入游戏后，关闭不需要的对象，使用预制体生成）
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobalTestManager : MonoBehaviour
{

    [Header("需关闭显示的测试对象")] public List<GameObject> Test_Targets;

    void Awake()
    {
        foreach (var item in Test_Targets)
        {
            item.SetActive(false);
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
