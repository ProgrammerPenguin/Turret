using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargetting : MonoBehaviour
{
    public int sightAngle = 180;
    public bool IsTargettingOn { get; private set; }
    public GameObject Target { get; private set; }

    void OnTriggerStay(Collider other)
    {
        if(isTargetInsight(gameObject.transform.position,other.transform.position,gameObject.transform.forward))
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

    public bool isTargetInsight(Vector3 turret, Vector3 target, Vector3 forward)
    {
        Debug.Log("e드,ㄹ어모");
        Vector3 targetDirection = (target - turret).normalized;
        float dotProduct = Vector3.Dot(forward.normalized, targetDirection);
        Debug.Log($"내접{dotProduct}");
        float theta = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        if (dotProduct > 0 && theta > 30)
        {
            return true;
        }
        else
        {
            return false;
        }


        //return theta <= sightAngle / 2;
    }
}
