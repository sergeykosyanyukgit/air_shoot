using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour{

    public GameObject dead;
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "enemy"){
            Instantiate(dead, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
