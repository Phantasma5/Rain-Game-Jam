using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    Camera mainCam;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = FindObjectOfType<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        mainCam.transform.position = player.transform.position;
    }
}
