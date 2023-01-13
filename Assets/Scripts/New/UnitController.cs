using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitController : MonoBehaviour
{
    Unit unit;

    void Awake()
    {
        unit = new Unit(transform);
        InputHandle.Instance.SelectUnit(unit);
    }


    void Update()
    {
        var command = InputHandle.Instance.HandleInput();
        if (command != null)
            command.Execute();
    }
}
