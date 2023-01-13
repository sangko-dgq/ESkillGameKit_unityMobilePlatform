using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    


    [Header("Float - Speed of Projectile to Fly")] public float projectileMoveSpeed;
    [Header("Float - Rate of Projectile to Fire")] public float fireRate;
    [Header("Float - max distance range of Projectile to Fly")] public float maxSkillRange;
    [Header("Prefab - muzzle")] public GameObject muzzlePrefab;
    [Header("Prefab - hit")] public GameObject hitPrefab;

    AudioSource audioSource_Hit;
    private GameObject OBJ_audioSource_Hit;
    private GameObject OBJ_Player;



    void Start()
    {
        OBJ_audioSource_Hit = GameObject.FindGameObjectWithTag("OBJ_audioSource_Hit");
        OBJ_Player = GameObject.FindGameObjectWithTag("OBJ_Player");
        audioSource_Hit = OBJ_audioSource_Hit.GetComponent<AudioSource>();

        if (muzzlePrefab != null)
        {
            var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
            var psMuzzle = muzzleVFX.GetComponent<ParticleSystem>();
            if (psMuzzle != null)
            {
                Destroy(muzzleVFX, psMuzzle.main.duration);
            }
            else
            {
                var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(muzzleVFX, psChild.main.duration);
            }
        }
    }

    void FixedUpdate()
    {
        if (projectileMoveSpeed != 0)
        {
            transform.position += transform.forward * (projectileMoveSpeed * Time.deltaTime);
        }
        else
            Debug.Log("[Warnning ]Please set projectileMoveSpeed value!");

        float disFromPlayerProjectile = (OBJ_Player.transform.position - transform.position).magnitude;//获取相对距离且取模
        //超出设定技能范围
        if (disFromPlayerProjectile >= maxSkillRange)
        {
            // Debug.Log("disFromPlayerProjectile : " + disFromPlayerProjectile);
            Destroy(gameObject);
        }

    }


    //当击中目标或障碍物
    void OnCollisionEnter(Collision co)
    {
        audioSource_Hit.Play();
        projectileMoveSpeed = 0;

        ContactPoint contact = co.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if (hitPrefab != null)
        {
            // Debug.Log(this.transform.position.x);
            var hitVFX = Instantiate(hitPrefab, pos, rot);
            var psHit = hitVFX.GetComponent<ParticleSystem>();
            if (psHit != null)
            {
                Destroy(hitVFX, psHit.main.duration);
            }
            else
            {
                var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(hitVFX, psChild.main.duration);
            }

            Destroy(gameObject);
        }

        // Debug.Log("OnCollisionEnter!!");
    }


    void Update()
    {
        //动态检测预制体初始值，防止忘记打开预制体设置初始值（注意：预制体public变量不支持代码初始化）
        if(projectileMoveSpeed == 0 || fireRate == 0|| maxSkillRange == 0)
        {
            Debug.Log("[Warring] Exist value == 0!!!");
        }
    }
}
