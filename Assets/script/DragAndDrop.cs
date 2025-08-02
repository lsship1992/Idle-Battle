using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
public class DragAndDrop : MonoBehaviour,IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Image image;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        Debug.Log(gameObject.transform.parent.name);
        if (gameObject.transform.parent.name != "Content")
        {
            image.color = new Color(0f, 255f, 200f, 0.7f);
            image.raycastTarget = false;
        }
        
    } 
    public void OnDrag(PointerEventData eventData)
    {
        if (gameObject.transform.parent.name != "Content")
        {
            rectTransform.anchoredPosition += eventData.delta;

        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (gameObject.transform.parent.name != "Content")
        {
            image.color = new Color(255f, 255, 255, 1);
            image.raycastTarget = true;
        }

            
    }
}
