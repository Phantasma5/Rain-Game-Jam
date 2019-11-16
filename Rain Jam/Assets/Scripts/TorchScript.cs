using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{
    private StatSystem myStatSystem;
    [SerializeField] private GameObject flame;
    [SerializeField] private GameObject light;
    private void Start()
    {
        myStatSystem = GetComponent<StatSystem>();
        myStatSystem.AddCallBack(StatSystem.StatType.Heat, UpdateFlame);

        myStatSystem.Callback(StatSystem.StatType.Heat);
    }
    private void UpdateFlame(StatSystem.StatType aStat, float aValue)
    {
        if(aValue > 0)
        {
            flame.SetActive(true);
            light.SetActive(true);
        }
        else
        {
            flame.SetActive(false);
            light.SetActive(false);
        }
    }
    private void Update()
    {
        if(flame.activeInHierarchy == true)
        {
            References.playerStatSystem.AddValue(StatSystem.StatType.Heat, 2 * Time.deltaTime);
        }
    }
}
