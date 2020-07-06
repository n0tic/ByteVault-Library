using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler, IPointerDownHandler {

    [SerializeField] private RectTransform dragRectTransform;
    [SerializeField] private Canvas canvas;

    private void Awake() {
        if (dragRectTransform == null) {
            dragRectTransform = transform.parent.GetComponent<RectTransform>();
        }

        if (canvas == null) {
            Transform testCanvasTransform = transform.parent;
            while (testCanvasTransform != null) {
                canvas = testCanvasTransform.GetComponent<Canvas>();
                if (canvas != null) {
                    break;
                }
                testCanvasTransform = testCanvasTransform.parent;
            }
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if(IsMovableWindowInsideScreenSize(eventData.position)) 
            dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData) {
        dragRectTransform.SetAsLastSibling();
    }

    public bool IsMovableWindowInsideScreenSize(Vector2 data)
    {
        if (data.x >= 10 && data.x <= Screen.currentResolution.width - 10 && data.y >= 10 && data.y <= Screen.currentResolution.height - 10)
            return true;
        else
            return false;
    }
}
