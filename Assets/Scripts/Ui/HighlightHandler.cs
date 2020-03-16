using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighlightHandler : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IPointerExitHandler {
    public Sprite normalSprite;
    public Sprite selectedSprite;
    public GameObject imageObject;
    public float xDimension;
    public float YDimension;
    public GameObject audioController;

    public void OnPointerEnter(PointerEventData eventData) {
        if(imageObject.GetComponent<SpriteRenderer>() != null) {
            imageObject.GetComponent<SpriteRenderer>().sprite = selectedSprite;
            imageObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(70, 70, 1);
            audioController.GetComponent<AudioManager>().Play("InterfaceHover");
        }
        else {
            this.transform.localScale = new Vector3(1.4f, 1.4f, 1);
            imageObject.GetComponent<Image>().sprite = selectedSprite;
            audioController.GetComponent<AudioManager>().Play("InterfaceHover");
            //imageObject.GetComponent<Image>().transform.localScale = new Vector3(70, 70, 1);
        }
        
    }
    public void OnPointerExit(PointerEventData eventData) {
        if (imageObject.GetComponent<SpriteRenderer>() != null) {
            imageObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(45, 45, 1);
            imageObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
        }
        else {
            this.transform.localScale = new Vector3(1, 1, 1);
            //imageObject.GetComponent<Image>().transform.localScale = new Vector3(45, 45, 1);
            imageObject.GetComponent<Image>().sprite = normalSprite;
        }
    }

    public void OnSelect(BaseEventData eventData) {
        if (imageObject.GetComponent<SpriteRenderer>() != null) {
            imageObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(45, 45, 1);
            imageObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
            audioController.GetComponent<AudioManager>().Play("InterfaceSelect");
        }
        else {
            this.transform.localScale = new Vector3(1, 1, 1);
            audioController.GetComponent<AudioManager>().Play("InterfaceSelect");
            //imageObject.GetComponent<Image>().= new Vector3(45, 45, 1);
            imageObject.GetComponent<Image>().sprite = normalSprite;
        }
    }
}
