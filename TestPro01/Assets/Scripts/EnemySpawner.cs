using UnityEngine;

using System.Collections.Generic;


public class EnemySpawner : MonoBehaviour
{
    // The enemy prefab to be spawned.
    public GameObject enemy;

    // An array of the spawn points this enemy can spawn from.
    private Transform[] spawnPoints;

    public float maxTime = 50;

    public float minTime = 10;

    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;


    void Awake()
    {

        List<Transform> spawningPointsAsList = new List<Transform>();

        // Get All the children of the object this script is assigned to (EnemyManager) and consider them as spawining points
        foreach (Transform child in transform)
        {
            spawningPointsAsList.Add(child);
        }

        spawnPoints = spawningPointsAsList.ToArray();
    }


    void Start()
    {
        SetRandomTime();
        time = 0;
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
        Debug.Log("Next object spawn in " + spawnTime + " seconds.");
    }

    void FixedUpdate()
    {
        //Counts up
        time += Time.deltaTime;
        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            Debug.Log("Time to spawn: " + enemy.name);
            Spawn();
            SetRandomTime();
            time = 0;
        }
    }


    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Debug.Log("my index" + spawnPoints[0].position);
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position + new Vector3(Random.Range(0,2),0, Random.Range(0, 5)), spawnPoints[spawnPointIndex].rotation);
    }
}
