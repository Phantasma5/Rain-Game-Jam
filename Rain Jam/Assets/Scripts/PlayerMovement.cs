using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
    float moveSideWays;
    References refInstance;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = FindObjectOfType<Camera>();
        refInstance = FindObjectOfType<References>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
        moveForward = Input.GetAxis("Horizontal") * movementSpeed;
        moveSideWays = Input.GetAxis("Vertical") * movementSpeed;
        rotateX += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        rotateY -= Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, rotateX, 0);
        mainCam.transform.eulerAngles = new Vector3(rotateY, rotateX, 0);

        GetComponent<Rigidbody>().AddRelativeForce(moveForward, 0, moveSideWays);

        if(Input.GetButtonDown("Jump"))
        {
            if(Physics.Raycast(transform.position, Vector3.down, 1))
            {
                GetComponent<Rigidbody>().AddForce(0, 5, 0, ForceMode.Impulse);
            }
        }

        if(!Physics.Raycast(transform.position, Vector3.up, 20))
        {
            References.playerStatSystem.AddValue(StatSystem.StatType.Heat, -damage * Time.deltaTime);
            Debug.Log(References.playerStatSystem.GetValue(StatSystem.StatType.Heat));
        }
    }
}
