using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject scorezonePrefab;
    List<GameObject> obstacles = new List<GameObject>();
    
    float xSpawn = 15f;
    int obstacleIndex = 0;

    bool applyEffects = false;

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
        Vector3 randomGen = new Vector3(0, Random.Range(-1.4f, 2.1f), 0);
        Vector3 positionBottom = new Vector3(xSpawn, -5, 0) + randomGen;
        Vector3 positionTop = new Vector3(xSpawn, 5, 0) + randomGen;
        Vector3 scoreZone = new Vector3(xSpawn, 0, 0) + randomGen;
        GameObject currentBottom = Instantiate(obstaclePrefab, positionBottom, transform.rotation);
        GameObject currentTop = Instantiate(obstaclePrefab, positionTop, transform.rotation);      
        GameObject currentScoreZone = Instantiate(scorezonePrefab, scoreZone, transform.rotation);         

        if(applyEffects) {
            currentBottom.GetComponent<ObstacleEffects>().Activate();
            currentTop.GetComponent<ObstacleEffects>().Activate();
        }


        //adds obstacle to list until the max of 4 pairs and then starts to replace them
        //also adds a ScoreZone
        if (obstacleIndex < 5)
        {
            obstacles.Add(currentBottom);
            obstacles.Add(currentTop);
            obstacles.Add(currentScoreZone);         
        }
        else
        {
            //destroys the oldest pair of obstacles and the oldest ScoreZone
            Destroy(obstacles[0]);
            Destroy(obstacles[1]);
            Destroy(obstacles[2]);                   
            obstacles.RemoveAt(0);                
            obstacles.RemoveAt(0);
            obstacles.RemoveAt(0);               
            
            //adds the newest pair of obstacles and a ScoreZone
            obstacles.Add(currentBottom);
            obstacles.Add(currentTop);
            obstacles.Add(currentScoreZone);         
        }
    }

    public void InvisibleObjects() {
        for(int i = 0; i < obstacles.Count; i++)
        {
            obstacles[i].GetComponent<ObstacleEffects>().Activate();
        }
        applyEffects = true;
    }

    public void VisibleObjects() {
        for(int i = 0; i < obstacles.Count; i++)
        {
            obstacles[i].GetComponent<ObstacleEffects>().Deactivate();
        }
        applyEffects = false;
    }
    //Dash method, called when atDash event is detected. Calls Dashed method in ObstacleMovement for every Obstacle on the scene
    public void Dash(){

        int n = 0;
        int p = obstacles.Count;
        
        while (n<p){
            obstacles[n].GetComponent<ObstacleMovement>().Dashed();
            n++;
        }

    }

    //Pull method, called when atPull event is detected
    //finds the first obstacle that has a x position greater than the player's position
    //then gives the y position of the ScoreZone (previous obstacle + 2 in the list) and gives it to the player
    public void Pull(){
        GameObject player = GameObject.Find("Player");

        float playerX = player.transform.position.x;
        float obstacleX = 0;
        float pullY = 0;

        int n = 0;
        int p = obstacles.Count;
        
        while (n<p){
            obstacleX = obstacles[n].transform.position.x;
            if (obstacleX-playerX>=0){
                pullY = obstacles[n+2].transform.position.y;
                n = 20;
            }
            n++;
        }


        player.transform.position = new Vector3(-4,pullY,0);
    }

}
