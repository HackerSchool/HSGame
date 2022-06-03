using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    public float minScaleX = 7.333768f;
    public float originalScaleX;
    private float ratio;
    public bool activated = false;
    public bool dark = false;
    public float duration = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        ratio = transform.localScale.x/transform.localScale.y;
        GameObject player = GameObject.Find("Player");
        transform.parent = player.transform;
        transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        originalScaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(activated && !dark) {
            Darken();
        } 
        else if(activated && duration > 0) {
            duration -= Time.deltaTime;
        }
        else{
            Lighten();
        }
    }

    public void Lighten() {
        if(transform.localScale.x < originalScaleX) {
            Vector3 scale = (Vector3.right*ratio + Vector3.up) * Time.deltaTime * 4;
            transform.localScale += scale;

            UpdateAlpha(-1);
        } else {
            Destroy(gameObject);
        }
    }
    public void Darken() {
        if(transform.localScale.x > minScaleX) {
            Vector3 scale = (Vector3.right*ratio + Vector3.up) * Time.deltaTime * 4;
            transform.localScale -= scale;

            UpdateAlpha(1);
        } else {
            dark = true;
        }
    }

    void UpdateAlpha(float _scale) {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a += 0.2f * Time.deltaTime * _scale;
        tmp.a = Mathf.Min(tmp.a, 0.8f);
        GetComponent<SpriteRenderer>().color = tmp;
    }

    public void SetDuration(float _duration) {
        this.duration = _duration;
        activated = true;
    }
}
