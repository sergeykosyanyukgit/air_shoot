using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyTypeOne : MonoBehaviour{

    public float fireRate = 0.3f;
    private float time = 0.0f;
    public GameObject bullet;

    public Image imgHp;
    float hp = 100;
    float maxHp;

    Animator animator;
    public float minAnimRate = 2.0f;
    public float maxAnimRate = 4.0f;
    private float timeAnim = 0.0f;
    bool swAnim = false;

    bool forward = false;
    float forw = 0.3f;
    GameObject hero;
    heroController heroController;
    void Start(){
        maxHp = hp;
        time = fireRate;
        timeAnim = maxAnimRate;
        animator = GetComponent<Animator>();
        hero = GameObject.Find("Hero");
        heroController = hero.GetComponent<heroController>();
    }

    void Update(){
        if(!forward){
            forw -= Time.deltaTime;
            if (forw <= 0.0f){
                forward = true;
                animator.SetBool("go", true);
            }
        }else{
            UpdateFire();
            UpdateAnim();
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "greenLaser" && forward) {
            hp-=10;
            imgHp.fillAmount = hp/maxHp;
            if(hp <= 0){
                heroController.AddScore(10);
                Destroy(gameObject, 0.25f);
            }
        }
    }
    private void UpdateFire(){
        fireRate -= Time.deltaTime;
        if (fireRate <= 0.0f){
            fireRate = time;
            Instantiate (bullet, transform.position, transform.rotation);
        }
    }
    void UpdateAnim(){
        timeAnim -= Time.deltaTime;
        if (timeAnim <= 0.0f){
            float rand = Random.Range(minAnimRate, maxAnimRate);
            animator.speed = rand;
            timeAnim = rand;
            swAnim = !swAnim;
            animator.SetBool("anim", swAnim);
        }
    }
}
