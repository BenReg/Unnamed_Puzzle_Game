using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Rendering.ShadowCascadeGUI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image image;
    private RectTransform rectTransform;
    private Transform originalParent;
    private Canvas canvas;
    private Vector3 originalScale;
    [SerializeField] private bool isDraggable = true;
    public GridSO cell;
    GameObject dragGhost;
    



    private void Awake()
    {
        if (!isDraggable) return;
        image = GetComponent<Image>();
        //rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalScale = transform.localScale;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;
        Debug.Log("OnBeginDrag");
        /*originalParent = transform.parent;
        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();*/

        dragGhost = new GameObject("DragGhost");
        dragGhost.AddComponent<Image>().sprite = image.sprite;
        dragGhost.transform.localScale = new Vector3(2, 2, 1);
        originalParent = dragGhost.transform.parent;
        dragGhost.transform.SetParent(canvas.transform);
        dragGhost.transform.SetAsLastSibling();

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;
        Debug.Log("OnDrag");
        dragGhost.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;
        Debug.Log("OnEndDrag");
        //transform.SetParent(originalParent);

        Destroy(dragGhost);
    }


    /*public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isDraggable) return;
        Debug.Log("OnPointerEnter");
        //image = GetComponent<Image>();
        //dragGhost = new GameObject("DragGhost");
        //dragGhost.AddComponent<Image>().sprite = image.sprite;
        transform.localScale = originalScale * 2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isDraggable) return;
        Debug.Log("OnPointerExit");
        transform.localScale = originalScale;
        //Destroy(dragGhost);
    }*/
}
