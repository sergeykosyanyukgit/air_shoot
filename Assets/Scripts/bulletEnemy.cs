using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemy : MonoBehaviour
{

    public GameObject dead;
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "hero"){
            Instantiate(dead, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
