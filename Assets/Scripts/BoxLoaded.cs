using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BoxLoaded : MonoBehaviour
{
    private GameObject _truck;

    private void Update()
    {
        _truck = GameObject.Find("Truck");
        var tempPosition = _truck.transform.position;
        tempPosition = new Vector3(tempPosition.x + -0.00203f, tempPosition.y + -0.02628f, tempPosition.z + 0.02264f);
        this.transform.position = tempPosition;
    }
}
