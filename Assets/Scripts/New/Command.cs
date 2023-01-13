using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Unit
{
    Transform transform;
    public Unit(Transform transform)
    {
        this.transform = transform;
    }
    public void MoveTo(Vector3 aimPos)
    {
        // Debug.Log(aimPos);
        transform.position = aimPos;
    }


    public void SetPos(Vector3 aimPos)
    {
        transform.forward = (aimPos - transform.position).normalized; //玩家朝向 =  (目标位置 - 玩家当前位置).单元化
        transform.position = aimPos;
    }
}


/*
                        命令封装
*/


public class CmdSetPos : Command
{
    Unit unit;
    Vector3 aimPos;
    public CmdSetPos(Unit unit, Vector3 pos)
    {
        this.unit = unit;
        this.aimPos = pos;
    }

    public override void Execute()
    {
        unit.SetPos(aimPos);

    }
}

public abstract class Command
{

    public abstract void Execute();


}

/*
                        输入处理
*/
public class InputHandle : Singleton<InputHandle>
{

    Unit unit;
    public void SelectUnit(Unit unit)
    {
        this.unit = unit;
    }

    public Command HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            return new MoveToCommand(unit, Vector3.zero);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            return new CmdSetPos(unit, Vector3.zero);
        }

        return null;
    }
}

public class MoveToCommand : Command
{
    Unit unit;
    Vector3 aimPos;
    public MoveToCommand(Unit unit, Vector3 pos)
    {
        this.unit = unit;
        this.aimPos = pos;
    }

    public override void Execute()
    {
        unit.MoveTo(aimPos);

    }
}
