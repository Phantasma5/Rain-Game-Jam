using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    [SerializeField] private float buoyancy;
    [SerializeField] private float damage;
    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb)
        {
            if (rb.velocity.y < 2)
            {
                rb.AddForce(new Vector3(0, buoyancy * Time.deltaTime, 0));
            }
        }

        switch (other.tag)
        {
            case "Player":
                References.playerStatSystem.AddValue(StatSystem.StatType.Heat, -damage * Time.deltaTime);
                break;
            case "Fire":
                Destroy(other.gameObject);
                break;
        }
    }
}
