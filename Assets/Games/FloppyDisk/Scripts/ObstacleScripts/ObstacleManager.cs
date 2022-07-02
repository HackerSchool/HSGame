using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    
    public float maxHeight;
    public float minHeight;
    List<GameObject> obstacles = new List<GameObject>();
    float timer = 0.0f;
    bool dashing = false;
    float xSpawn = 15f;
    int obstacleIndex = 0;
    float spawnRate = 1.3f;
    bool applyEffects = false;
    IEnumerator spawnRoutine = null;

    //Spawns first obstacle
    void Start()
    {
        //Coroutine to spawn obstacles each 1.5 seconds
        spawnRoutine = ExecuteSpawnObstacle();
        StartCoroutine(spawnRoutine);
    }

    void Update() {
    }

    IEnumerator ExecuteSpawnObstacle()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void SpawnObstacle()
    {

        //calculates position of obstacle and instantiates it
        obstacleIndex++;
        Vector3 obstaclePosition = new Vector3(xSpawn, Random.Range(minHeight, maxHeight), 0);
        GameObject obstacle = Instantiate(obstaclePrefab, obstaclePosition, transform.rotation);      

        if(applyEffects) {
            obstacle.GetComponent<ObstacleEffects>().Activate();
        }
       
        obstacles.Add(obstacle);    
        
        if(obstacles[0] == null) {
            obstacles.RemoveAt(0); 
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

        GameObject obstacle;
        

        int n = 0;
        int p = obstacles.Count;
        
        while (n<p){
            obstacle = obstacles[n];
            if (obstacles[n]!=null){
                obstacles[n].GetComponent<ObstacleMovement>().Dashed();
            }
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

        GameObject obstacle;
        
        while (n<p){
            obstacle = obstacles[n];
            if (obstacle!=null){
                obstacleX = obstacles[n].transform.position.x;
                if (obstacleX-playerX>=0){
                    pullY = obstacles[n+2].transform.position.y;
                    n = 20;
                }
            }
            n++;
        }


        player.transform.position = new Vector3(-4,pullY,0);
    }

    public bool NoObjects() {
        if(obstacles.Count != 0 && obstacles[obstacles.Count - 1] == null) {
            obstacles.Clear();
        }
        return obstacles.Count == 0;
    }

    public void SpawnRandomObstacle(float y_pos) {
        GameObject obstacle = Instantiate(obstaclePrefab);
        Vector3 pos = obstacle.transform.position;
        pos.y = y_pos;
        pos.x = xSpawn;
        obstacle.transform.position = pos;
        obstacle.transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);
    }

    public void Activate() {
        StartCoroutine(spawnRoutine);
    }
    public void Deactivate() {
        StopCoroutine(spawnRoutine);
    }
}
