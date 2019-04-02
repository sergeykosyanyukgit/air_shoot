using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgControl : MonoBehaviour
{   
    public GameObject[] backgrounds;
    GameObject room;
    public int bgNumber = 0;
    void Start()
    {
        room = (GameObject)Instantiate(backgrounds[bgNumber], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D col = room.GetComponent<Collider2D>();
        float maxY = col.bounds.max.y;
        if(maxY<=5.5f){
            room = Generate(maxY);
        }
        Debug.Log(maxY);
    }
    GameObject Generate(float positionY){
        //int generate = Random.Range(0, backgrounds.Length);
        GameObject room = (GameObject)Instantiate(backgrounds[bgNumber], new Vector2(transform.position.x, positionY+5.0f), transform.rotation);
        return room;
    }
}
