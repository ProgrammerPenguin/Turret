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
    // Start is called before the first frame update
    void Awake()
    {
        _turretTargetting = GetComponent<TurretTargetting>();
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
        //transform.Rotate(0f, TurretHeadSpeed* Time.deltaTime, 0f);
    }

}
