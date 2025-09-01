using System;
using UnityEngine;
using UnityEngine.UI;

public class CellScript : MonoBehaviour
{

    [SerializeField] private Image spriteImage;
    [SerializeField] public Boolean isInventoryCell;

    private void Awake()
    {
        spriteImage = GetComponent<Image>();
        isInventoryCell = false;
    }

    public void setCellData(GridSO data)
    {
        Debug.Log(data.spriteCell);
        if (data != null)
        {
            Debug.Log("test");
            spriteImage.sprite = data.spriteCell;
        }
    }

}
