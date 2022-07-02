using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEffects : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private float decreasingSpeed = 0.5f; 
    private bool invisible = false;
    private float timer = 0.0f;
    private bool activated = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(activated) FadeInFadeOut();
        else {
            if(spriteRenderer.color.a < 1.0f) {
                Color tmp = spriteRenderer.color;
                tmp.a += 0.3f * Time.deltaTime;
            }
        }
    }

    void FadeInFadeOut() {
        Color tmp = spriteRenderer.color;
        if(invisible) {
            timer += Time.deltaTime;
            if(timer > 0.4f) {
                timer = 0.0f;
                invisible = false;
                tmp.a = 0.01f;
                decreasingSpeed = -decreasingSpeed;
            }
        }
        else {
            tmp.a -= Time.deltaTime * decreasingSpeed;
            if(tmp.a < 0.0f) invisible = true;
            if(tmp.a > 1.0f){
                decreasingSpeed = -decreasingSpeed;
                tmp.a = 1.0f;
            } 
            spriteRenderer.color = tmp;
        }
    }

    public void Activate() {
        activated = true;
    }

    public void Deactivate() {
        activated = false;
    }
}
