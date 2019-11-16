using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSystem : MonoBehaviour
{
    [SerializeField] private List<Stat> myStats = new List<Stat>();
    [HideInInspector] public delegate void StatUpdateFunction(StatType aStat, float aNewValue);
    Dictionary<StatType, StatUpdateFunction> callbacks = new Dictionary<StatType, StatUpdateFunction>();

    public enum StatType
    {
        First,
        Heat,
        Matches,
        Last
    }

    [System.Serializable]
    public class Stat
    {
        public StatType type;
        public float value;
        public float maxValue;
    }
    public void AddCallBack(StatType aStat, StatUpdateFunction aFn)
    {
        if (callbacks.ContainsKey(aStat))
        {
            callbacks[aStat] += aFn;
        }
        else
        {
            callbacks[aStat] = aFn;
        }
    }

    public float GetValue(StatType aStat)
    {
        foreach (var stat in myStats)
        {
            if (stat.type == aStat)
            {
                return stat.value;
            }
        }
        return (float.MinValue);
    }
    public float GetMaxValue(StatType aStat)
    {
        foreach (var stat in myStats)
        {
            if (stat.type == aStat)
            {
                return stat.maxValue;
            }
        }
        return (float.MinValue);
    }

    public void AddValue(StatType aStat, float aValue)
    {
        if(0 == aValue)
        {
            return;
        }
        foreach (var stat in myStats)
        {
            if(stat.type == aStat)
            {
                stat.value += aValue;
                if(stat.value > stat.maxValue)
                {
                    stat.value = stat.maxValue;
                }
                if(stat.value < 0)
                {
                    stat.value = 0;
                }
                Callback(aStat);
            }
        }
    }
    public void SetValue(StatType aStat, float aValue)
    {
        foreach (var stat in myStats)
        {
            if (stat.type == aStat)
            {
                if(stat.value == aValue)
                {
                    continue;
                }
                stat.value = aValue;
                if (stat.value > stat.maxValue)
                {
                    stat.value = stat.maxValue;
                }
                Callback(aStat);
            }
        }
    }
    public void Callback(StatType aStat)
    {
        if(!callbacks.ContainsKey(aStat))
        {
            return;
        }
        foreach (var item in myStats)
        {
            if(item.type == aStat)
            {
                callbacks[aStat](aStat, item.value);
            }
        }
    }
}
