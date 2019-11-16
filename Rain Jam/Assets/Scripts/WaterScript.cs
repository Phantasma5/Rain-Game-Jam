using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    [SerializeField] private float buoyancy;
    [SerializeField] private float damage;
    private void OnTriggerStay(Collider other)
    {
        switch(other.tag)
        {
            case "Player":
                References.playerStatSystem.AddValue(StatSystem.StatType.Heat, -damage * Time.deltaTime);
                if(2 > References.playerRigidbody.velocity.y)
                {
                    References.playerRigidbody.AddForce(new Vector3(0, buoyancy*Time.deltaTime, 0));
                }
                break;
        }
    }
}
