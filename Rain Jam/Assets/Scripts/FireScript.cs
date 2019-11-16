using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    [SerializeField] private float healing;
    private void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                References.playerStatSystem.AddValue(StatSystem.StatType.Heat, healing * Time.deltaTime);
                break;
        }
    }
}
