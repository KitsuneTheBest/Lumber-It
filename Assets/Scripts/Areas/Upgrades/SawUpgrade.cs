using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawUpgrade : MonoBehaviour
{
    public float DamageUpgradeScale;
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
            other.GetComponent<TruckStats>().Damage += DamageUpgradeScale;
            Debug.Log("Saw upgrade, damage increased by " + DamageUpgradeScale);
        }
    }
}
