using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundData : MonoBehaviour
{
    public GameObject linker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOffReset() {
        foreach(Transform t in transform) {
            if(t != transform) {
                t.gameObject.GetComponent<Parallax>().resetOn = false;
            }
        }
    }
}
