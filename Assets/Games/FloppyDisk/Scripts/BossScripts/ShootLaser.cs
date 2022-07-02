using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootLaser : MonoBehaviour
{
    [SerializeField] UnityEvent onComplete;
    public Vector3 startPos;
    public float shootHeight;
    public Vector3 laserOrigin;
    public GameObject laserPrefab;

    public IEnumerator PrepareFire()
    {
        while (!Mathf.Approximately(shootHeight - transform.position.y, 0.0f))
        {
            yield return null;
            Vector3 target = transform.position;
            target.y = shootHeight;
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime*1.5f);
        }
        yield return StartCoroutine(Shoot());
    }

    public IEnumerator Shoot()
    {
        GameObject laser = GameObject.Instantiate(laserPrefab);
        laser.transform.parent = transform;
        laser.transform.localPosition = laserOrigin;
        while (Vector3.Distance(startPos, transform.position) > 0.01f)
        {
            yield return null;
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime*1.5f);
        }
        GameObject.Destroy(laser);
        onComplete.Invoke();
    }
}
