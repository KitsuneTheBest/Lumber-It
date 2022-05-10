using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unload : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Truck")) return;
        var load = other.GetComponent<TruckStats>().Load;
        other.GetComponent<TruckStats>().Money += load * 100;
        other.GetComponent<TruckStats>().Load = 0;
        Debug.Log("Truck unloaded");
        Debug.Log("Money received, total balance: " + other.GetComponent<TruckStats>().Money);
    }
}
