using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    List<GameObject> obstacles = new List<GameObject>();
    GameObject obstacleManager;
    float xSpawn = 15f;
    int obstacleIndex = 0;

    // Runs before the start and will assign the game object so we can get the parents position
    void Awake()
    {
        obstacleManager = GameObject.Find("ObstacleManager");
    }
    //Spawns first obstacle
    void Start()
    {
        SpawnObstacle(new Vector3(0, 0, 0));
    }

    void LateUpdate()
    {
        SpawnObstacle(obstacleManager.transform.parent.transform.position);
    }

    void SpawnObstacle(Vector3 currentPosition)
    {
        if ((int)System.Math.Floor(currentPosition.x) / 10 > this.obstacleIndex - 1)
        {
            //calculates position of obstacle and instantiates it
            obstacleIndex++;
            Vector3 positionBottom = new Vector3(currentPosition.x + xSpawn, -5, 0);
            Vector3 positionTop = new Vector3(currentPosition.x + xSpawn, 5, 0);
            //TODO: scale of obstacles
            GameObject currentBottom = Instantiate(obstaclePrefab, positionBottom, transform.rotation);
            GameObject currentTop = Instantiate(obstaclePrefab, positionTop, transform.rotation);

            //adds obstacle to list until the max of 4 pairs and then starts to replace them
            if (obstacleIndex < 4)
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
}
