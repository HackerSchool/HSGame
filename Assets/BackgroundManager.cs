using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{

    public List<GameObject> backgrounds;
    public List<GameObject> transistions;
    private GameObject current;
    private GameObject transition;
    private GameObject previous = null;
    public GameObject cam;
    private int index = 0;
    private int transitionIndex = 0;
    private bool inTransition = false;
    private bool finishTransition = false;

    private int sortingOrder = 1;
    // Start is called before the first frame update
    void Start()
    {
        current = Instantiate(backgrounds[index]);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(inTransition) {
            if(CoincidesWithCamera(transition)) {
                inTransition = false;
                finishTransition = true;
                LoadNextBackground(transition.transform.Find("Linker").gameObject);
            }
        }

        else if(finishTransition) {
            if(CoincidesWithCamera(current)) {
                Destroy(transition);
                Destroy(previous);
                finishTransition = false;
            }
        }
    }

    // First method called when it is necessary to change the current game background
    // Stops the parallax reset from all elements of the current background, finds
    // the element that connects the other background and starts the transition
    public void ChangeBackground() {
        GameObject linker = null;
        foreach(Transform t in current.transform) {
            if(t.gameObject != current) {
                t.gameObject.GetComponent<Parallax>().resetOn = false;
                if(t.gameObject.name == "Linker") linker = t.gameObject;
            }
        }
        inTransition = true;
        BackgroundTransition(linker);
    }

    // Method that loads the transition background to connect the current to next
    public void BackgroundTransition(GameObject linker) {
        transition = Instantiate(transistions[transitionIndex]);
        transitionIndex = (transitionIndex + 1) % transistions.Count;

        ChangeOrderInLayer(transition);
        float offset =  linker.GetComponent<SpriteRenderer>().bounds.size.x*2 +
                        linker.transform.position.x;

        transition.transform.position = Vector3.right*offset;
        transition.transform.GetChild(0).GetComponent<Parallax>().resetOn = false;
    }

    // Method that loads the next background
    public void LoadNextBackground(GameObject linker) {
        index = (index+1)%backgrounds.Count;

        previous = current;
        current = Instantiate(backgrounds[index]);
        ChangeOrderInLayer(current);
        float offset = linker.GetComponent<SpriteRenderer>().bounds.size.x +
                       linker.transform.position.x;
        current.transform.position = Vector3.right*offset;
    }

    private bool CoincidesWithCamera(GameObject background) {
        GameObject g = background.transform.Find("Linker").gameObject;
        float dist = cam.transform.position.x - g.transform.position.x;
        return (dist <= 0.1 && dist >= -0.1);
    }

    private void ChangeOrderInLayer(GameObject background) {
        foreach(Transform t in background.transform) {
            if(t.gameObject != background) {
                t.gameObject.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
            }
        }
        sortingOrder++;
    }
}