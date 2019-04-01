using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroController : MonoBehaviour{

    private Vector3 positionMove;
    public float speed = 5.0f;

    public float fireRate = 0.1f;
    private float time = 0.0f;

    public GameObject bullet;

    private void Start(){
        positionMove = transform.position;
        time = fireRate;
    }

    private void Update(){
        
        UpdateFire();
        UpdateInput();
        UpdateMove();
    }

    private void UpdateInput(){
        positionMove = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        positionMove.z = 0;
    }

    private void UpdateMove(){
        float moveDelta = (positionMove - transform.position).magnitude;
        if (moveDelta <= speed * Time.deltaTime)
        {
            transform.position = positionMove;
            return;
        }
        Vector3 moveDir = positionMove - transform.position;
        moveDir.Normalize();
        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void UpdateFire(){
        fireRate -= Time.deltaTime;
        if (fireRate <= 0.0f){
            timerEnded();
        }
    }

    void timerEnded(){
       fireRate = time;
       Instantiate (bullet, transform.position, transform.rotation);
    }
}
