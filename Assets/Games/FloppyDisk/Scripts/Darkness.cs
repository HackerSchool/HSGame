using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    public float minScaleX = 7.333768f;
    public float minScaleY = 7.0f;
    public float originalScaleX;
    public float originalScaleY;
    public float originalAlpha;
    private float ratio;
    public float maxAlpha = 0.85f;
    public bool activated = true;

    public float angle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        ratio = minScaleX/minScaleY;
        GameObject player = GameObject.Find("Player");
        transform.parent = player.transform;
        transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        originalScaleX = transform.localScale.x;
        originalScaleY = transform.localScale.y;
        originalAlpha = GetComponent<SpriteRenderer>().color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(activated) Darken();
        else Lighten();

        angle = 120.0f * Time.deltaTime;
        if(Camera.main.transform.rotation.eulerAngles.z < 180.0f)
            Camera.main.transform.Rotate(Vector3.forward * angle);
        else {
            Camera.main.transform.Rotate(Vector3.forward * (180.0f - Camera.main.transform.rotation.eulerAngles.z));
        }
    }

    public void Lighten() {
        if(transform.localScale.x < originalScaleX) {
            transform.localScale += Vector3.right * Time.deltaTime * ratio * 2;
        }
        if(transform.localScale.y < originalScaleY) {
            transform.localScale += Vector3.up * Time.deltaTime * 2;
        }      
        if(GetComponent<SpriteRenderer>().color.a > originalAlpha) {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a -= 0.8f * Time.deltaTime;
            GetComponent<SpriteRenderer>().color = tmp;
        }


        if(transform.localScale.x >= originalScaleX) {
            Destroy(gameObject);
        }
    }
    public void Darken() {
        if(transform.localScale.x > minScaleX) {
            transform.localScale -= Vector3.right * Time.deltaTime * ratio * 2;
        }
        if(transform.localScale.y > minScaleY) {
            transform.localScale -= Vector3.up * Time.deltaTime * 2;
        }
        else {
            Deactivate();
        }        
        if(GetComponent<SpriteRenderer>().color.a < maxAlpha) {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a += 0.8f * Time.deltaTime;
            GetComponent<SpriteRenderer>().color = tmp;
        }
    }

    public void Deactivate() {
        activated = false;
    }
}
