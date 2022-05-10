using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkUpgrade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Truck")) return;
        var money = other.gameObject.GetComponent<TruckStats>().Money;
        if (money < 1000)
        {
            Debug.Log("Insufficient funds");
        }
        else
        {
            money -= 1000;
            other.gameObject.GetComponent<TruckStats>().Money = money;
            other.GetComponent<TruckStats>().Capacity += 5;
            Debug.Log("Trunk upgrade, capacity increased by 5");
        }
    }
}
