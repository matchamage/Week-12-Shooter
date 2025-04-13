using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject shieldPowerUpPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyBigPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyBig", 1, 3);
        InvokeRepeating("SpawnShieldPowerUp", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }
    void CreateEnemyBig()
    {
        Instantiate(enemyBigPrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    void SpawnShieldPowerUp()
    {
        Instantiate(shieldPowerUpPrefab, new Vector3(Random.Range(-8.38f, 8.38f), 6.5f, 0), Quaternion.identity);
    }
}
