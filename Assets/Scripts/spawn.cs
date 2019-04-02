using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour{

    public GameObject[] enemy;
    public GameObject[] meteor;
    public GameObject[] bonus;

    public float enemySpawnRate = 4.0f;
    float enemySpawnTime = 0.0f;

    public float meteorSpawnRate = 5.0f;
    float meteorSpawnTime = 0.0f;

    public float bonusSpawnRate = 10.0f;
    float bonusSpawnTime = 0.0f;

    public GameObject left;
    public GameObject right;

    private float spawnPositionY;
    void Start(){
        enemySpawnTime = enemySpawnRate;
        meteorSpawnTime = meteorSpawnRate;
        bonusSpawnTime = bonusSpawnRate;

        spawnPositionY = gameObject.transform.position.y;
    }

    void Update(){
        SpawnEnemy();
        SpawnMeteor();
        SpawnBonus();
    }

    private void SpawnEnemy(){
        enemySpawnRate -= Time.deltaTime;
        if (enemySpawnRate <= 0.0f){
            enemySpawnRate = enemySpawnTime;
            Vector2 vec = new Vector2(Random.Range(left.transform.position.x, right.transform.position.x), spawnPositionY);
            int generate = Random.Range(0, enemy.Length);
            Instantiate (enemy[generate], vec , transform.rotation);
        }
    }

    private void SpawnMeteor(){
        meteorSpawnRate -= Time.deltaTime;
        if (meteorSpawnRate <= 0.0f){
            meteorSpawnRate = meteorSpawnTime;
            Vector2 vec = new Vector2(Random.Range(left.transform.position.x, right.transform.position.x), spawnPositionY);
            int generate = Random.Range(0, meteor.Length);
            Instantiate (meteor[generate], vec , transform.rotation);
        }
    }

    private void SpawnBonus(){
        bonusSpawnRate -= Time.deltaTime;
        if (bonusSpawnRate <= 0.0f){
            bonusSpawnRate = bonusSpawnTime;
            Vector2 vec = new Vector2(Random.Range(left.transform.position.x, right.transform.position.x), spawnPositionY);
            int generate = Random.Range(0, bonus.Length);
            Instantiate (bonus[generate], vec , transform.rotation);
        }
    }
}
