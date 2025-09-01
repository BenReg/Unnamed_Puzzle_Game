using UnityEngine;

public class CreateGridLayout : MonoBehaviour
{

    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private ModeleSO ModeleData;
    [SerializeField] private bool isPlayerGrid = false;

    //[SerializeField] private GridSO[] cellsData;
    private int rows = 3;
    private int columns = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateEmptyGrid();
    }

    private void OnEnable()
    {
        ModeleManager.OnModeleChosen += LoadModele;
    }

    private void OnDisable()
    {
        ModeleManager.OnModeleChosen -= LoadModele;
    }

    public void LoadModele(ModeleSO newModele)
    {
        if (!isPlayerGrid)
        {
            ClearGrid();
            ModeleData = newModele;
            GenerateModelGrid();
        }
    }

    private void ClearGrid()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void GenerateEmptyGrid()
    {
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                GameObject cellObj = Instantiate(cellPrefab, transform);
                var draggable = cellObj.GetComponent<DraggableItem>();
                /*if (draggable != null)
                {
                    draggable.enabled = false; // d�sactive le script
                }*/
            }
        }
    }

    public void GenerateModelGrid()
    {
        GridSO[] cellsData = ModeleData.cellsData;
        Debug.Log("test2");
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                GameObject cellObj = Instantiate(cellPrefab, transform);
                CellScript cell = cellObj.GetComponent<CellScript>();
                var draggable = cellObj.GetComponent<DraggableItem>();
                if (draggable != null)
                {
                    draggable.enabled = false; // d�sactive le script
                }

                int index = y * columns + x;
                if (index < cellsData.Length)
                {
                    cell.setCellData(cellsData[index]);
                }
            }
        }
    }
}
