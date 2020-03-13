using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighlightHandler : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IPointerExitHandler {
    public Sprite normalSprite;
    public Sprite selectedSprite;
    public GameObject imageObject;
    public void OnPointerEnter(PointerEventData eventData) {
        if(imageObject.GetComponent<SpriteRenderer>() != null) {
            imageObject.GetComponent<SpriteRenderer>().sprite = selectedSprite;
        }
        else {
            imageObject.GetComponent<Image>().sprite = selectedSprite;
        }
        
    }
    public void OnPointerExit(PointerEventData eventData) {
        if (imageObject.GetComponent<SpriteRenderer>() != null) {
            imageObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
        }
        else {
            imageObject.GetComponent<Image>().sprite = normalSprite;
        }
    }

    public void OnSelect(BaseEventData eventData) {
        Debug.Log("Selected");
    }
}
