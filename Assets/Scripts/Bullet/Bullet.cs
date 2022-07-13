using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;
    public float BigBulletSpeed;
    public float SmallBulletSpeed;
    public float BulletSize;
    public float BigBulletSize;
    public float SmallBulletSize;
    public int MinNum = 3;
    public int MaxNum = 12;

    private float _radNum;
    private Rigidbody _bulletRigdbody;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        _radNum = Random.Range(MinNum, MaxNum);
        _bulletRigdbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //_radNum = Random.Range(MinNum, MaxNum);
        if ((_radNum - MinNum) % 3 == 0)
        {
            bulletType(BigBulletSize, BigBulletSpeed);
        }
        else if ((_radNum - MinNum) % 3 == 1)
        {
            bulletType(SmallBulletSize, SmallBulletSpeed);
        }
        else
        {
            bulletType(BulletSize, BulletSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.SetActive(false);
        }
    }

    void bulletType(float size, float speed)
    {
        transform.localScale = new Vector3(size, size, 5 * size);
        transform.Translate(0f, 0f, speed * Time.deltaTime);
    }

}
