using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    float delayBetweenWaves = 30f;
    [SerializeField]
    int enemiesPerWave = 10;
    [SerializeField]
    float delayPerEnemy = 2f;

    [SerializeField]
    GameObject enemyPrefabYellow;
    [SerializeField]
    GameObject enemyPrefabBlue;

    [SerializeField]
    Text clockText;
    float time = 0f;

    [SerializeField]
    float symptomDelay = 10f;
    float addSymptomDelay = 30f;
    [SerializeField]
    int maxSymptoms = 3;
    int numSymptoms = 1;

    float elapsedTime = 0;
    List<GameObject> enemyPrefabs;

    enum Symptoms
    {
        coughing,       // 0
        fever,          // 1
        fatigue,        // 2
        headache,       // 3
        max_symptoms    // 4
    }
    // symptoms[0] = coughing
    // symptoms[1] = fever
    // symptoms[2] = fatigue
    static List<bool> symptoms;

    // Start is called before the first frame update
    void Start()
    {
        enemyPrefabs = new List<GameObject>();
        enemyPrefabs.Add(enemyPrefabYellow);
        enemyPrefabs.Add(enemyPrefabBlue);

        Random.InitState(System.DateTime.Now.Millisecond);

        symptoms = new List<bool>();
        for (int i = 0; i < (int)Symptoms.max_symptoms; ++i)
        {
            symptoms.Add(false);
        }

        StartCoroutine(activateSymptoms());
        StartCoroutine(addSymptom());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        elapsedTime += Time.deltaTime;
        if (elapsedTime > delayBetweenWaves)
        {
            StartCoroutine(spawnWave());
            elapsedTime = 0;
        }
        clockText.text = "Time: " + time.ToString("f2");
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

        Vector3 randomPos = Vector3.zero;
        float randomX = 0f;
        float randomY = 0f;

        randomX = Random.Range(-7.5f, 7.5f);
        randomY = Random.Range(-2.5f, 2.5f);
        randomPos = new Vector3(randomX, randomY, 0);

        GameObject instance = Instantiate(enemy, randomPos, Quaternion.identity);
        instance.transform.localScale = new Vector3(.3f, .3f, 1);
        if (symptoms[(int)Symptoms.fever])
        {
            instance.GetComponentInChildren<Enemy>().increaseSpeed();
        }
    }

    IEnumerator activateSymptoms()
    {
        while (true)
        {
            Debug.Log("activateSymptom CAlled!");

            for (int i = 0; i < symptoms.Count; ++i)
            {
                symptoms[i] = false;
            }
            for (int i = 0; i < numSymptoms; ++i)
            {
                int index = Random.Range(0, symptoms.Count);
                while (symptoms[index])
                {
                    index = Random.Range(0, symptoms.Count);
                    Debug.Log("Reroll");
                }
                symptoms[index] = true;
                Debug.Log("active symptom index: " + index);
            }

            yield return new WaitForSeconds(symptomDelay);
        }
    }

    IEnumerator addSymptom()
    {
        while (true)
        {
            yield return new WaitForSeconds(addSymptomDelay);
            ++numSymptoms;
        }
    }

    public static bool IsSymptomCoughing()
    {
        return symptoms[(int)Symptoms.coughing];
    }
    public static bool IsSymptomFever()
    {
        return symptoms[(int)Symptoms.fever];
    }
    public static bool IsSymptomFatigue()
    {
        return symptoms[(int)Symptoms.fatigue];
    }
    public static bool IsSymptomHeadache()
    {
        return symptoms[(int)Symptoms.headache];
    }
}
