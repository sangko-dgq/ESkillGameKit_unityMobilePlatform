using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXPlayBox : MonoBehaviour
{
    Animator ator;

    [Header("请选择需要控制的VisualEffectGraph")] public VisualEffect visualEffect;
    VisualEffect vfx_clone;

    public void PlayVFX()
    {
        Debug.Log("AN EVENT TEST00000!");
    }


    public void PlayVFX_Kass_A()
    {
        Debug.Log("Play VFX_Kass!!!");

        GameObject.FindGameObjectWithTag("VFX_Prefab").GetComponent<VisualEffect>().playRate = 0.5f;
        GameObject.FindGameObjectWithTag("VFX_Prefab").GetComponent<VisualEffect>().Play();
        
        


        ator = GameObject.FindGameObjectWithTag("OBJ_Player").GetComponent<Animator>();
        ator.SetBool("isSkillA", false);

    }
    public void StopVFX_Kass_A()
    {
        if (vfx_clone != null)
            vfx_clone.GetComponent<VisualEffect>().Stop();
    }
}
