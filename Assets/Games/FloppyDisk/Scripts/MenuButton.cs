using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI text;
    public Color hoverColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = hoverColor;
        text.fontSize *= 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.white;
        text.fontSize /= 1.2f;
    }
}
