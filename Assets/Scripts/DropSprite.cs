using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSprite : MonoBehaviour, IDropHandler
{
    private Image image;
    //private CellScript cell;

    private void Awake()
    {
        image = GetComponent<Image>();
       // cell = GetComponent<CellScript>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        Debug.Log(image.sprite);

        DraggableItem dragged = eventData.pointerDrag.GetComponent<DraggableItem>();
        if (dragged != null)
        {
            image.sprite = dragged.cell.spriteCell;

            //if (puzzleCell != null)
           // {
           //     puzzleCell.SetData(dragged.pieceData);
           // }
        }
    }

}
