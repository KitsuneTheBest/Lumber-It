using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollect : MonoBehaviour
{
    public GameObject BoxPrefab;
    private GameObject _truck;

    private void Awake()
    {
        _truck = GameObject.Find("Truck");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Truck")) 
        {
            var load = other.GetComponent<TruckStats>().Load;
            if (load < other.GetComponent<TruckStats>().Capacity)
            {
                Destroy(this.gameObject);
                Debug.Log("Box collected");
                other.GetComponent<TruckStats>().Load += 1;
            }
            else
            {
                Debug.Log("Truck is full");
            }
            // GameObject box = Instantiate(BoxPrefab) as GameObject;
            // var tempPosition = truck.transform.position;
            // tempPosition = new Vector3(tempPosition.x + -0.00203f, tempPosition.y + -0.02628f, tempPosition.z + 0.02264f);
            // box.transform.position = tempPosition;
        }
    }
}
