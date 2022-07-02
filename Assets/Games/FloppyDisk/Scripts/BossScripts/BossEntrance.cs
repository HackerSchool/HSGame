using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossEntrance : MonoBehaviour
{
    public float entranceSpeed;
    public Vector3 startPosition;
    public Vector3 endPosition;
    [SerializeField] UnityEvent completed; 
   
    public IEnumerator StartEntrance()
    {
        while (Vector3.Distance(transform.position, endPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, Time.deltaTime*entranceSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        transform.position = endPosition;
        completed.Invoke();
    }
}
