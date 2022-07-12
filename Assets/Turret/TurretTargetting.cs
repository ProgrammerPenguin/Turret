using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargetting : MonoBehaviour
{
    public bool IsTargettingOn { get; private set; }
    public GameObject Target { get; private set; }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            IsTargettingOn = true;
            Target = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        IsTargettingOn = false;
        Target = null;
    }
}
