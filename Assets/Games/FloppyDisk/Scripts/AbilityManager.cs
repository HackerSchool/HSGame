using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    float bouncePower = 8f;

    public UnityEvent atDash;
    public UnityEvent atPull;

    float coolDownOne = 0f;
    float coolDownTwo = 0f;
    float coolDownThree = 0f;

    float coolDownUnlock = 0f;

    public int abilityControl = 0;

    Rigidbody2D rigidbodyComponent;

    public Text abilityOneText;
    public Text abilityTwoText;
    public Text abilityThreeText;

    public Text abilityUnlockText;

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();

        abilityOneText = GameObject.Find("AbilityOneText").GetComponent<Text>();
        abilityTwoText = GameObject.Find("AbilityTwoText").GetComponent<Text>();
        abilityThreeText = GameObject.Find("AbilityThreeText").GetComponent<Text>();

        abilityUnlockText = GameObject.Find("AbilityUnlockText").GetComponent<Text>();

        if (atDash == null){
            atDash = new UnityEvent();
        }
        if (atPull == null){
            atPull = new UnityEvent();
        }
    }

    public void ZoneTwo(){
        Debug.Log("called");
        abilityUnlockText.text = ("Electrical Dash unlocked!\nPress Q to dash forward");
        coolDownUnlock = 10f;
        abilityOneText.text = ("Q");
        abilityControl = 1;
        Debug.LogFormat("cont = {0}", abilityControl);
    }

    public void ZoneThree(){
        abilityUnlockText.text = ("Magnetic Pull unlocked!\nPress W to pull yourself to a safer hight");
        coolDownUnlock = 10f;
        abilityTwoText.text = ("W");
        abilityControl = 2;
        Debug.LogFormat("cont = {0}", abilityControl);
    }

    public void ZoneFour(){
        abilityUnlockText.text = ("Ghostly Form unlocked!\nPress E to avoid an obstacle");
        coolDownUnlock = 10f;
        abilityThreeText.text = ("E");
        abilityControl = 3;
        Debug.LogFormat("cont = {0}", abilityControl);
    }

    //onDash input, begins atDash event
    void OnDash(InputValue value){   
        if (atDash != null && abilityControl>=1 && coolDownOne<=0){
            atDash.Invoke();
            coolDownOne = 15f;
        }
    }

    //onPull input, begins atPull event
    void OnPull(InputValue value){
        if (atPull != null && abilityControl>=2 && coolDownTwo<=0){
            rigidbodyComponent.velocity = Vector2.down*0;
            atPull.Invoke();
            coolDownTwo=15f;
        }
    }

    //onGhost input, no event required
    void OnGhost(InputValue value){
        if (abilityControl>=3 && coolDownThree<=0){
            GetComponent<Collider2D>().isTrigger = true;
            GetComponent<Renderer>().material.color = new Color(1.5f, 1.5f, 2.0f, 0.5f);
            coolDownThree=15f;
        }
    }


    //methods to handle ghostly collisions
    //when leaving an obstacle remove invincibility
    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Obstacle")){
            GetComponent<Collider2D>().isTrigger = false;
            GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

    //when colliding with the floor, makes the player bounce without loosing invincibility
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Floor")){
            if (GetComponent<Collider2D>().isTrigger == true){
                rigidbodyComponent.velocity = Vector2.up * bouncePower;
            }
        }
    }

    //timers of the abilities' cooldowns
    void Update(){
        if (coolDownOne>0){
            coolDownOne -= Time.deltaTime;
            abilityOneText.text = Mathf.RoundToInt(coolDownOne).ToString("");
        }
        else if (abilityControl>=1){
            abilityOneText.text = ("Q");
        }
        if (coolDownTwo>0){
            coolDownTwo -= Time.deltaTime;
            abilityTwoText.text = Mathf.RoundToInt(coolDownTwo).ToString("");
        }
        else if (abilityControl>=2){
            abilityTwoText.text = ("W");
        }
        if (coolDownThree>0){
            abilityThreeText.text = Mathf.RoundToInt(coolDownThree).ToString("");
            coolDownThree -= Time.deltaTime;
        }
        else if (abilityControl>=3){
            abilityThreeText.text = ("E");
        }
        if(coolDownUnlock>0){
            coolDownUnlock -= Time.deltaTime;
        }
        else {
            abilityUnlockText.text = ("");
        }
    }
}
