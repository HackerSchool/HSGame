using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject scorezonePrefab;
    public GameObject floor;
    public GameObject ceil;
    List<GameObject> obstacles = new List<GameObject>();
    float timer = 0.0f;
    bool dashing = false;
    float xSpawn = 15f;
    int obstacleIndex = 0;
    float spawnRate = 2.5f;

    bool applyEffects = false;

    //Spawns first obstacle
    void Start()
    {
        floor = GameObject.Find("Floor");
        ceil = GameObject.Find("Ceiling");

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
            yield return new WaitForSeconds(spawnRate);
            int rand = Random.Range(1, 100);
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        float yScaleBottom = Random.Range(1.0f, 2.7f);
        float yScaleTop = Random.Range(1.0f, 2.7f);

        float floorSpawn = floor.transform.position.y + yScaleBottom / 2 + 0.5f;
        float ceilSpawn = ceil.transform.position.y - yScaleTop / 2 - 0.5f;

        //calculates position of obstacle and instantiates it
        obstacleIndex++;
        Vector3 positionBottom = new Vector3(xSpawn, floorSpawn, 0);
        Vector3 positionTop = new Vector3(xSpawn, ceilSpawn, 0);
        Vector3 scoreZone = new Vector3(xSpawn, (ceilSpawn+floorSpawn)/2, 0);
        GameObject currentBottom = Instantiate(obstaclePrefab);
        GameObject currentTop = Instantiate(obstaclePrefab, positionTop, transform.rotation);
        currentBottom.transform.localScale = new Vector3(1, yScaleBottom, 1);
        currentBottom.transform.position = positionBottom;
        currentTop.transform.localScale = new Vector3(1, yScaleTop, 1);
        currentTop.transform.position = positionTop;

        GameObject currentScoreZone = Instantiate(scorezonePrefab, scoreZone, transform.rotation);         

        if(applyEffects) {
            currentBottom.GetComponent<ObstacleEffects>().Activate();
            currentTop.GetComponent<ObstacleEffects>().Activate();
        }
       
        obstacles.Add(currentBottom);
        obstacles.Add(currentTop);
        obstacles.Add(currentScoreZone);         
        
        if(obstacles[0] == null) {
            obstacles.RemoveRange(0, Mathf.Min(3, obstacles.Count)); 
        }

        //TO REMOVE
        spawnRate -= Time.deltaTime * 10;
        spawnRate = Mathf.Max(1.0f, spawnRate);    
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

    void Update() {
    }
}
