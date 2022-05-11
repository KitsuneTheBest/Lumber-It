using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TreeBehaviour : MonoBehaviour
{
    public float Health = 100;
    public float TotalHealth = 100;
    public TruckStats TruckStats;
    public GameObject BoxPrefab;
    private bool _damaging = false;

    private void Update()
    {
        //this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, Health/TotalHealth);
    }

    private void FixedUpdate()
    {
        if (!_damaging) return;
        Health -= TruckStats.Damage * 0.5f;
        //Debug.Log("Health: " + Health);
        if (!(Health < 0.1)) return;
        var treePosition = this.gameObject.transform.position;
        Destroy(this.gameObject);
        Debug.Log("Tree destroyed");
        GameObject box = Instantiate(BoxPrefab) as GameObject;
        box.transform.position = treePosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Truck")) 
        {
            _damaging = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Truck")) 
        {
            _damaging = false;
        }
    }
}
