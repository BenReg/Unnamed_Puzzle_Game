using UnityEngine;

[CreateAssetMenu(fileName = "ModeleSO", menuName = "Scriptable Objects/ModeleSO")]
public class ModeleSO : ScriptableObject
{
    public string modeleName;
    public GridSO[] cellsData;
    public int rows = 3;
    public int comumns = 3;
}
