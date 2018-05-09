using System.Collections;
using System.Collections.Generic;
using DaydreamElements.ArmModels;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class DaydreamZapperEvent : MonoBehaviour
{
    public UnityEvent OnZapped;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Projectile>())
        {
            OnZapped.Invoke();
        }
    }
}
