using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead : MonoBehaviour
{
    public float deadTime = 0.1f;
    void Start()
    {
        Destroy(gameObject, deadTime);
    }
}
