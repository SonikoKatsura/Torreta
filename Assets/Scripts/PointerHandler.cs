using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class PointerHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private bool isHover = false;

    public void OnPointerEnter(PointerEventData eventData) {
        isHover = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        isHover = false;
    }

    void Update() {
        if (isHover) GameObject.Find("GameManager").GetComponent<GameManager>().DisableFire();
    }
}
