using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    public Transform FollowTarget;
    public Vector3 FollowOffset;

    // Start is called before the first frame update
    void Start()
    {
        if(FollowTarget)
        {
            FollowOffset = transform.position - FollowTarget.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = FollowTarget.position + FollowOffset;
    }
}
