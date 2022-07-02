using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState {
    OFF,
    ENTERING,
    IDLE,
    SHOOTING
} 

public class BossEffects : MonoBehaviour
{
    [SerializeField] BossMovement movement;
    [SerializeField] ThrowObstacle throwObstacle;
    [SerializeField] ShootLaser shootLaser;
    [SerializeField] BossEntrance entrance;
    [SerializeField] BossState state;

    bool throwing = false;
    bool shooting = false;
    float timer = 0.0f;
    float interval = 0.1f;
    bool onInterval = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(state) {
            case BossState.IDLE:
                ShootLaser();
                break;
            default:
                break;
        }
        /*
        if(!shooting && movement.Ready() && Random.Range(0, 101) < 5)
        {
            StopCoroutine(throwObstacle.ExecuteThrowObstacle());
            throwing = false;

            movement.StopFloating();
            StartCoroutine(shootLaser.PrepareFire());
            shooting = true;
        }
        */
    }

    private void ShootLaser()
    {
        if(!onInterval)
        {
            int rand = Random.Range(0, 101);
            if(rand < 3) {
                StartShooting();
            }
            else {
                onInterval = true;
            }
        }
        else {
            timer += Time.deltaTime;
            if(timer >= interval) {
                timer = 0.0f;
                onInterval = false;
            }
        }
    }

    private void StartShooting()
    {
        state = BossState.SHOOTING;
        movement.enabled = false;
        StartCoroutine(shootLaser.PrepareFire());
    }

    public void StartEntry()
    {
        state = BossState.ENTERING;
        StartCoroutine(entrance.StartEntrance());
    }
    public void StartMovement()
    {
        state = BossState.IDLE;
        movement.enabled = true;
    }
}
