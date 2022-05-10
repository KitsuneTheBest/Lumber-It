using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ChangeUIText : MonoBehaviour
{
    public Text Money;
    public Text Load;
    public Text Capacity;
    public Text Damage;
    public Text Speed;
    public GameObject Truck;

    private void Update()
    {
        Money.text = "Money: " + Truck.GetComponent<TruckStats>().Money;
        Load.text = "Load: " + Truck.GetComponent<TruckStats>().Load;
        Capacity.text = "Capacity: " + Truck.GetComponent<TruckStats>().Capacity;
        Damage.text = "Damage: " + Truck.GetComponent<TruckStats>().Damage;
        Speed.text = "Speed: " + Truck.GetComponent<TruckMovement>().Speed;
    }
}
