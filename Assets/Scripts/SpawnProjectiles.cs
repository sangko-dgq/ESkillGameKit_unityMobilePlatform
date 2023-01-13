using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnProjectiles : MonoBehaviour
{

    [Header("List - VFX Prefabs")] public List<GameObject> vfx = new List<GameObject>();
    [Header("C# - RotateToMouse.cs")] public RotateToMouse rotateToMouse;
    [Header("C# - RnimCtr.cs")] public AnimCtrl animCtr;
    [Header("Btn - ButtonSkillMain")] public Button buttonSkillMain;


    private GameObject firePoint;
    private GameObject effectToSpawn;
    private float timeToFire = 0;

    private Animator ator;
    private AudioSource audioSource;
    private AnimatorStateInfo stateInfo;


    void Start()
    {
        effectToSpawn = vfx[0];
        audioSource = this.GetComponent<AudioSource>();
        buttonSkillMain = buttonSkillMain.GetComponent<Button>();
    }

    void Update()
    {
        //AnimatorStateInfo>1 来判断动画结束，必须放在update里不断检测，不能放在按键监听里（会检测失效）
        if (!animCtr.GetAnimCtrl().GetBool("isShooting")) return;
        AnimatorStateInfo animatorInfo;
        ator = animCtr.GetAnimCtrl();
        animatorInfo = ator.GetCurrentAnimatorStateInfo(0);
        if ((animatorInfo.normalizedTime > 1.0f) && (animatorInfo.IsName("Shooting")))//normalizedTime: 范围0 -- 1,  0是动作开始，1是动作结束
        {
            //Debug.Log("动画播放完毕");
            audioSource.Play();
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            SpawnVFX();

            ator.SetBool("isShooting", false);
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;
        firePoint = GameObject.FindGameObjectWithTag("FirePoint");

        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            if (rotateToMouse != null)
            {
                //   Debug.Log(rotateToMouse.GetRotation());
                vfx.transform.localRotation = GameObject.FindGameObjectWithTag("OBJ_Player").transform.localRotation;
            }
        }
        else
            Debug.Log("No Fire Point!");

    }


    void OnEnable()
    {
        buttonSkillMain.onClick.AddListener(() => shotSkillMain());
    }

    void shotSkillMain()
    {
        if (animCtr == null) return;
        if (Time.time < timeToFire) return;

        ator = animCtr.GetAnimCtrl();
        stateInfo = ator.GetCurrentAnimatorStateInfo(0);

        //原地射击
        if (!ator.GetBool("isWalking"))
        {
            ator.SetBool("isShooting", true);
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            //Debug.Log("原地点击射击");
        }
        //移动射击
        else
        {
            audioSource.Play();
            //TODO
            SpawnVFX();
            //Debug.Log("移动点击射击");
        }
    }
}
