using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float TurretHeadSpeed = 0f;
    public GameObject Bullet;
    public Transform BulletSpawnPoint;
    public float BulletSpawnTime = 0.5f;

    private float _totalDeltaTime;
    private TurretTargetting _turretTargetting;
    private SphereCollider _sphereCollider;
    // Start is called before the first frame update
    void Awake()
    {
        _turretTargetting = GetComponent<TurretTargetting>();
        _sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_turretTargetting.IsTargettingOn)
        {
            targetOn();
        }
        else
        {
            targetOff();
        }
    }
       
    void targetOn()
    {
        transform.LookAt(_turretTargetting.Target.transform);
        

        _totalDeltaTime += Time.deltaTime;
        if (_totalDeltaTime >= BulletSpawnTime)
        {
            _totalDeltaTime = 0f;
            Instantiate(Bullet, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
        }
    }
    void targetOff()
    {
        _totalDeltaTime = BulletSpawnTime;
        
        if(transform.rotation.y < 0)
        {
            transform.Rotate(0f, TurretHeadSpeed* Time.deltaTime, 0f);
        }
    }

}
