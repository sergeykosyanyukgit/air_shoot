using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heroController : MonoBehaviour{

    private Vector3 positionMove;
    public float speed = 5.0f;

    public float fireRate = 0.1f;
    private float time = 0.0f;

    public GameObject bullet;
    public GameObject bulletTwo;
    public GameObject bulletThree;

    public int lvl = 1;

    public Image imageHp;
    public Image imageShield;
    float hp = 100.0f;
    float shield = 50.0f;
    float maxHp;
    float maxShield;

    public Text score;
    public int scorepoints = 0;

    private void Start(){
        positionMove = transform.position;
        time = fireRate;
        maxHp = hp;
        maxShield = shield;
    }

    private void Update(){
        UpdateFire();
        UpdateInput();
        UpdateMove();
    }

    public void AddScore(int scored){
        scorepoints+=scored;
        score.text = "score: " + scorepoints;
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
        switch (lvl){   
            case 1:
                Instantiate (bullet, transform.position, transform.rotation);
            break;
            case 2:
                Instantiate (bulletTwo, transform.position, transform.rotation);
            break;
            case 3:
                Instantiate (bulletThree, transform.position, transform.rotation);
            break;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "redLaser") {
            Destroy(col.gameObject);
            hp-=10.0f;
            imageHp.fillAmount = hp/maxHp;
            if(hp <= 0){
                Destroy(gameObject, 0.25f);
            }
        }
        if(col.tag == "meteor") {
            Destroy(col.gameObject);
            hp-=10.0f;
            imageHp.fillAmount = hp/maxHp;
            if(hp <= 0){
                Destroy(gameObject, 0.25f);
            }   
        }
    }
}
