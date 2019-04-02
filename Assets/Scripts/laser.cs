using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public float speedLaserY = 10.0f;
    public float speedLaserX = 0.0f;
    
    public float deadTime = 2;
    public float rotateSpeed = 0.0f;
    void Start()
    {
        Destroy(gameObject, deadTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speedLaserX * Time.deltaTime, speedLaserY * Time.deltaTime, 0);
        if(rotateSpeed != 0.0f) transform.Rotate(0, 0, rotateSpeed);
    }
}
