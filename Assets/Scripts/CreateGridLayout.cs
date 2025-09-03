using UnityEngine;

public class CreateGridLayout : MonoBehaviour
{

    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private ModeleSO ModeleData;
    [SerializeField] private bool isPlayerGrid = false;

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
                //if (draggable != null)
                if (!isPlayerGrid)
                {
                    draggable.enabled = false;
                }
            }
        }
    }

    public void GenerateModelGrid()
    {
        GridSO[] cellsData = ModeleData.cellsData;
        Debug.Log("GenerateModelGrid");
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                GameObject cellObj = Instantiate(cellPrefab, transform);
                CellScript cell = cellObj.GetComponent<CellScript>();
                var draggable = cellObj.GetComponent<DraggableItem>();
                //if (draggable != null
                if (!isPlayerGrid)
                {
                    draggable.enabled = false;
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
