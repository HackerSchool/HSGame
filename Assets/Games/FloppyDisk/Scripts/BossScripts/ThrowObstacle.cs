using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObstacle : MonoBehaviour
{
    public float fireRate = 2.0f;
    public GameObject ObstacleManager;
    public IEnumerator ExecuteThrowObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            int rand = Random.Range(1, 100);
            throwObstacle();
        }
    }

    void throwObstacle() {
        ObstacleManager.GetComponent<ObstacleManager>().SpawnRandomObstacle(Random.Range(-1.5f, 1.5f));
    }
}
