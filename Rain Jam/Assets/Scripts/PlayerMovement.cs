using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ParticleSystem rain;
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float damage;
    Camera mainCam;
    float rotateX;
    float rotateY;
    float moveForward;
    float moveSideways;
    Vector3 xVel;
    Vector3 zVel;
    References refInstance;
    Rigidbody rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        mainCam = FindObjectOfType<Camera>();
        refInstance = FindObjectOfType<References>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveSideways= Input.GetAxis("Horizontal");
        moveForward = Input.GetAxis("Vertical");
        xVel = transform.right * moveSideways;
        zVel = transform.forward * moveForward;
        Vector3 movement = (xVel + zVel).normalized * movementSpeed;
        movement.y = rigidBody.velocity.y;
        rotateX += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        rotateY -= Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        
        transform.eulerAngles = new Vector3(0, rotateX, 0);
        if(rotateY < 90 && rotateY > -90)
        {
            mainCam.transform.eulerAngles = new Vector3(rotateY, rotateX, 0);
        }
        else
        {
            mainCam.transform.eulerAngles = new Vector3(Mathf.Sign(rotateY) * 89, rotateX, 0);
        }
        
        rigidBody.velocity = movement;

        if(Input.GetButtonDown("Jump"))
        {
            if (Physics.Raycast(transform.position, Vector3.down, 2))
            {
                rigidBody.AddForce(0, 5, 0, ForceMode.Impulse);
            }
        }

        if(!Physics.Raycast(transform.position, Vector3.up, 20)) //If there is no ceiling above you, take damage
        {
            References.playerStatSystem.AddValue(StatSystem.StatType.Heat, -damage * Time.deltaTime);
        }

        rain.transform.position = new Vector3(transform.position.x, rain.transform.position.y, transform.position.z);
    }
}
