using System;
using UnityEngine;

public class ModeleManager : MonoBehaviour
{
    [SerializeField] private ModeleSO[] ListeModeles;
    [SerializeField] private CreateGridLayout gridLayout;

    public static event Action<ModeleSO> OnModeleChosen;
     
    public void LoadModele (int index) // Méthode appelée sur le OnClick des boutons (directement dans l'inspecteur)
    {
        OnModeleChosen?.Invoke (ListeModeles[index]);
    }
    
}
