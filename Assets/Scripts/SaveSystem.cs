using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public GameObject Truck;
    
    public int DefaultMoney;
    public int DefaultLoad;
    public int DefaultCapacity;
    public float DefaultDamage;
    public float DefaultSpeed;
    

    private Save _save = new Save();
    private string _path;

    private void Start()
    {
        _path = Path.Combine(Application.dataPath, "Save.json");

        if (File.Exists(_path))
        {
            LoadStats();
            Debug.Log("Data loaded.");
        }
    }

    public void SaveStats()
    {
        _save.Money = Truck.GetComponent<TruckStats>().Money;
        _save.Load = Truck.GetComponent<TruckStats>().Load;
        _save.Capacity = Truck.GetComponent<TruckStats>().Capacity;
        _save.Damage = Truck.GetComponent<TruckStats>().Damage;
        _save.Speed = Truck.GetComponent<TruckMovement>().Speed;
        File.WriteAllText(_path, JsonUtility.ToJson(_save));
        Debug.Log("Data saved");
    }

    public void LoadStats()
    {
        _save = JsonUtility.FromJson<Save>(File.ReadAllText(_path));
        Truck.GetComponent<TruckStats>().Money = _save.Money;
        Truck.GetComponent<TruckStats>().Load = _save.Load;
        Truck.GetComponent<TruckStats>().Capacity = _save.Capacity;
        Truck.GetComponent<TruckStats>().Damage = _save.Damage;
        Truck.GetComponent<TruckMovement>().Speed = _save.Speed;
    }

    public void Reset()
    {
        _save.Money = DefaultMoney;
        _save.Load = DefaultLoad;
        _save.Capacity = DefaultCapacity;
        _save.Damage = DefaultDamage;
        _save.Speed = DefaultSpeed;
        File.WriteAllText(_path, JsonUtility.ToJson(_save));
        Debug.Log("Data reset");
        LoadStats();
    }
}

[Serializable]
public class Save
{
    public int Money;
    public int Load;
    public int Capacity;
    public float Damage;
    public float Speed;
}
