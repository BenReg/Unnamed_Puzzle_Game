using UnityEngine;

public class InventoryGridScript : MonoBehaviour
{

    private int rows = 1;
    private int columns = 6;
    [SerializeField] GridSO[] inventoryCells;
    [SerializeField] private GameObject inventoryCellPrefab;

    public void GenerateInventoryGrid()
    {
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                GameObject cellObj = Instantiate(inventoryCellPrefab, transform);
                CellScript cell = cellObj.GetComponent<CellScript>();

                int index = y * columns + x;
                if (index < inventoryCells.Length)
                {
                    cell.setCellData(inventoryCells[index]);
                }
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateInventoryGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
