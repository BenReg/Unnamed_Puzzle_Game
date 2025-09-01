using System;
using UnityEngine;

public class ModeleManager : MonoBehaviour
{
    [SerializeField] private ModeleSO[] ListeModeles;
    [SerializeField] private CreateGridLayout gridLayout;

    public static event Action<ModeleSO> OnModeleChosen;
     
    public void LoadModele (int index)
    {
        //gridLayout.LoadModele(ListeModeles[index]);
        OnModeleChosen?.Invoke (ListeModeles[index]);
    }
    
}
