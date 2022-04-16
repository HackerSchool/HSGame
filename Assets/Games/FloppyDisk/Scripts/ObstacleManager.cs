using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float xSpawn = 9f;
    public float xTrigger = 0f;
    
    void Start()
    {
        SpawnObstacle(Random.Range(0, obstaclePrefabs.Length));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacle(int obstacleIndex)
    {
        Vector3 position = Vector3.up * Random.Range(-2, 3) + Vector3.right * xSpawn;
        Instantiate(obstaclePrefabs[obstacleIndex], position, transform.rotation);
    }
}
