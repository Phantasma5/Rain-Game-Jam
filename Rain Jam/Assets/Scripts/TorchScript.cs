using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{
    private StatSystem myStatSystem;
    [SerializeField] private GameObject flame;
    private void Start()
    {
        myStatSystem = GetComponent<StatSystem>();
        myStatSystem.AddCallBack(StatSystem.StatType.Heat, UpdateFlame);
        myStatSystem.SetValue(StatSystem.StatType.Heat, 0);
    }
    private void UpdateFlame(StatSystem.StatType aStat, float aValue)
    {
        if(aValue > 0)
        {
            flame.SetActive(true);
        }
        else
        {
            flame.SetActive(false);
        }
    }
}
