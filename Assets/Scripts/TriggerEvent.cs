using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent<Collider> onTriggerEnter;
    public UnityEvent<Collider> onTriggerExit;

    void OnTriggerEnter(Collider col)
    {
        if (onTriggerEnter != null) onTriggerEnter.Invoke(col);
    }

    void OnTriggerExit(Collider col)
    {
        if (onTriggerExit != null) onTriggerExit.Invoke(col);
    }
}
