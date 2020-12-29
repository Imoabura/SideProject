using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    float delayBetweenWaves = 30f;
    [SerializeField]
    float enemiesPerWave = 10f;
    [SerializeField]
    float delayPerEnemy = 2f;

    [SerializeField]
    GameObject enemyPrefabYellow;
    [SerializeField]
    GameObject enemyPrefabBlue;

    float elapsedTime = 0;
    List<GameObject> enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        enemyPrefabs = new List<GameObject>();
        enemyPrefabs.Add(enemyPrefabYellow);
        enemyPrefabs.Add(enemyPrefabBlue);

        Random.InitState(System.DateTime.Now.Millisecond);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > delayBetweenWaves)
        {
            StartCoroutine(spawnWave());
            elapsedTime = 0;
        }
    }

    IEnumerator spawnWave()
    {
        for (int i = 0; i < enemiesPerWave; ++i)
        {
            spawnEnemy();
            yield return new WaitForSeconds(delayPerEnemy);
        }
    }

    void spawnEnemy()
    {
        int index = Random.Range(0, 2);
        GameObject enemy = enemyPrefabs[index];

        float randomX = Random.Range(-7.5f, 7.5f);
        float randomY = Random.Range(-4.5f, 4.5f);
        Vector3 randomPos = new Vector3(randomX, randomY, 0);

        GameObject instance = Instantiate(enemy, randomPos, Quaternion.identity);
    }
}
