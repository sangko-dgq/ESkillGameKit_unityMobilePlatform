using System.Collections;
using System.Collections.Generic;
// using UnityEngine.VFX;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    // Animator ator;

    // [Header("请选择需要控制的VisualEffectGraph")] public VisualEffect visualEffect;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HELLO!");

    }

    // public void PlayVFX_Kass_A()
    // {
    //     Debug.Log("Play VFX_Kass!!!");

    //     // visualEffect.Play();


    //     ator = GameObject.FindGameObjectWithTag("OBJ_Player").GetComponent<Animator>();
    //     ator.SetBool("isSkillA", false);
    // }
    // public void StopVFX_Kass_A()
    // {
    //     // visualEffect.Stop();
    // }

    public void PlayVFX()
    {
        Debug.Log("PlayVFX");
    }
}
