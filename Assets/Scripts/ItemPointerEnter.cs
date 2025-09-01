using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ItemPointerEnter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    private Canvas canvas;
    //private UnityEngine.Transform originalParent;

    private void Awake()
    {
        originalScale = transform.localScale;
        canvas = GetComponentInParent<Canvas>();
        //originalParent = transform.parent;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        transform.SetParent(canvas.transform);
        //transform.localScale = originalScale * 2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        transform.localScale = originalScale;
        //transform.SetParent(originalParent);
    }

}
