using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
  [SerializeField] RectTransform rectTransform;
  [SerializeField] Image image;

  private void Awake()
  {
    rectTransform = GetComponent<RectTransform>();
    image = GetComponent<Image>();
  }
  public void OnBeginDrag(PointerEventData eventData)
  {
    image.color = new Color(0f, 255f, 200f, 0.7f);
    image.raycastTarget = false;
  }

  public void OnDrag(PointerEventData eventData)
  {
    rectTransform.anchoredPosition += eventData.delta;
  }

  public void OnEndDrag(PointerEventData eventData)
  {
    image.color = new Color(255f, 255f, 255f, 1f);
    image.raycastTarget = true;
  }
}
