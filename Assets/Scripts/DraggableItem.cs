using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Rendering.ShadowCascadeGUI;

// Script permettant de g�rer le drag d'un item depuis la barre du bas
// Quand le joueur drag => un "fantome" est cr�e qui remplit bien la case c�t� mod�le joueur
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image image;
    private Image ghostImage;
    private Canvas canvas;
    [SerializeField] private bool isDraggable = true;
    public GridSO cell;
    GameObject dragGhost;
    private Color color;

    private void Awake()
    {
        if (!isDraggable) return;
        image = GetComponent<Image>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;
        Debug.Log("OnBeginDrag");

        dragGhost = new GameObject("DragGhost"); // on cr�e le "fantome" 2 fois plus gros que l'item pr�sent� dans la barre
        ghostImage = dragGhost.AddComponent<Image>();
        ghostImage.sprite = image.sprite;
        color = ghostImage.color;
        color.a = 0.6f;
        ghostImage.color = color;
        dragGhost.transform.localScale = new Vector3(2, 2, 1);
        
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

        Destroy(dragGhost); // on d�truit le fantome quand le drag s'arr�te
    }
}
