using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ItemPointerEnter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    private Canvas canvas;
    private GameObject bigGhost;
    private Image image;
    private RectTransform originalRect;
    private Color c;

    private void Awake()
    {
        image = GetComponent<Image>();
        originalScale = transform.localScale;
        canvas = GetComponentInParent<Canvas>();
        originalRect = GetComponent<RectTransform>();
        c = image.color;

    }

    // Quand le joueur passe la sourir au dessus d'une pièce de puzzle dans la barre d'items => elle grossit * 2 (la même taille qu'elle aura sur la modèle)
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");

        if (image != null) // rend transparent l'image de base pour pas qu'elle soit juste en dessous du "bigGhost"
        {
            c.a = 0f;
            image.color = c;
        }


        bigGhost = new GameObject("Big Ghost");
        bigGhost.transform.SetParent(canvas.transform, false); //on le fait passer dans le canvas car il dépasse de la barre d'item en taille

        Image popUpImage = bigGhost.AddComponent<Image>();
        popUpImage.sprite = image.sprite;
        popUpImage.raycastTarget = false; // permet de ne pas prendre en compte les actions de la souris
        RectTransform popupRect = bigGhost.GetComponent<RectTransform>();
        popupRect.position = originalRect.position;
        popupRect.sizeDelta = originalRect.sizeDelta * 2f;
        bigGhost.transform.SetAsLastSibling(); // passe devant les autres visuellement

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (image != null) // On remet l'image de base + petite
        {
            c.a = 1f;
            image.color = c;
        }

        Debug.Log("OnPointerExit"); // On détruit la "popUp" qui était + grosse
        if (bigGhost != null)
        {
            Destroy(bigGhost);
        }

    }

}
