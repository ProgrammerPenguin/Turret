using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargetting : MonoBehaviour
{
    public int sightAngle = 180;
    public bool IsTargettingOn { get; private set; }
    public GameObject Target { get; private set; }
    public GameObject FixedTurretHead;


    void OnTriggerStay(Collider other)
    {
        if (isTargetInsight(gameObject.transform.position, other.transform.position, FixedTurretHead.transform.forward))
        {
            if (other.tag == "Player")
            {
                IsTargettingOn = true;
                Target = other.gameObject;
            }
        }
        else
        {
            IsTargettingOn = false;
            Target = null;
        }
    }

    void OnTriggerExit(Collider other)
    {
        IsTargettingOn = false;
        Target = null;
    }

    private bool isTargetInsight(Vector3 turret, Vector3 target, Vector3 forward)
    {
        
        Vector3 targetDirection = (target - turret).normalized;

        float dotProduct = Vector3.Dot(forward.normalized, targetDirection);
        float theta = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        Vector3 crossProduct = Vector3.Cross(forward.normalized, targetDirection);

        if (dotProduct > 0 && theta > 30 && crossProduct.y < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
