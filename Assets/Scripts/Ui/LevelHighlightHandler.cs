using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelHighlightHandler : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IPointerExitHandler {
    public Sprite normalSprite;
    public Sprite selectedSprite;
    public GameObject imageObject;
    public float xDimension;
    public float YDimension;
    public GameObject audioController;
    [SerializeField] Sprite level;
    [SerializeField] GameObject levelName;

    public void OnPointerEnter(PointerEventData eventData) {

        if (imageObject.GetComponent<SpriteRenderer>() != null) {
            imageObject.GetComponent<SpriteRenderer>().sprite = selectedSprite;
            imageObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(70, 70, 1);
            audioController.GetComponent<AudioManager>().Play("InterfaceHover");
        } else {
            this.transform.localScale = new Vector3(1.4f, 1.4f, 1);
            imageObject.GetComponent<Image>().sprite = selectedSprite;
            audioController.GetComponent<AudioManager>().Play("InterfaceHover");
        }

        levelName.GetComponent<SpriteRenderer>().sprite = level;
        levelName.SetActive(true);

    }
    public void OnPointerExit(PointerEventData eventData) {
        if (imageObject.GetComponent<SpriteRenderer>() != null) {
            imageObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(45, 45, 1);
            imageObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
        } else {
            this.transform.localScale = new Vector3(1, 1, 1);
            imageObject.GetComponent<Image>().sprite = normalSprite;
        }
        levelName.SetActive(false);
    }

    public void OnSelect(BaseEventData eventData) {
        if (imageObject.GetComponent<SpriteRenderer>() != null) {
            imageObject.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(45, 45, 1);
            imageObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
            audioController.GetComponent<AudioManager>().Play("InterfaceSelect");
        } else {
            this.transform.localScale = new Vector3(1, 1, 1);
            audioController.GetComponent<AudioManager>().Play("InterfaceSelect");
            imageObject.GetComponent<Image>().sprite = normalSprite;
        }
    }
}
