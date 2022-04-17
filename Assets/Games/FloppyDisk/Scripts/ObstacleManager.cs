using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    List<GameObject> obstacles = new List<GameObject>();
    float xSpawn = 15f;
    int obstacleIndex = 0;

    //Spawns first obstacle
    void Start()
    {
        //Coroutine to spawn obstacles each 1.5 seconds
        StartCoroutine(ExecuteSpawnObstacle());
    }

    IEnumerator ExecuteSpawnObstacle()
    {
        //Spawns initial obstacle
        SpawnObstacle();
        while (true)
        {
            //Spawns new obstacle after 1.5 seconds
            yield return new WaitForSeconds(1.5f);
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        //calculates position of obstacle and instantiates it
        obstacleIndex++;
        Vector3 positionBottom = new Vector3(xSpawn, -5, 0);
        Vector3 positionTop = new Vector3(xSpawn, 5, 0);
        //TODO: scale of obstacles
        GameObject currentBottom = Instantiate(obstaclePrefab, positionBottom, transform.rotation);
        GameObject currentTop = Instantiate(obstaclePrefab, positionTop, transform.rotation);

        //adds obstacle to list until the max of 4 pairs and then starts to replace them
        if (obstacleIndex < 5)
        {
            obstacles.Add(currentBottom);
            obstacles.Add(currentTop);
        }
        else
        {
            //destroys the oldest pair of obstacles
            Destroy(obstacles[0]);
            Destroy(obstacles[1]);
            obstacles.RemoveAt(0);
            obstacles.RemoveAt(0);

            //adds the newest pair of obstacles
            obstacles.Add(currentBottom);
            obstacles.Add(currentTop);
        }
    }
}
