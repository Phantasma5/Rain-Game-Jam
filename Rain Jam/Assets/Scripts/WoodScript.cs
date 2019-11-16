using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodScript : MonoBehaviour
{
    public GameObject fire;
    public bool burn;
    // Start is called before the first frame update
    void Start()
    {
        fire.SetActive(false);
        burn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(burn == true)
        {
            fire.SetActive(true);
        }
    }
}
