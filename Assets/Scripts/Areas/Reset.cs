using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private SaveSystem _saveSystem;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Truck")) return;
        other.GetComponent<SaveSystem>().Reset();
    }
}
