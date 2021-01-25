using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBuildTower : MonoBehaviour
{
    public  Pool towerPool;
    public SelectedTower selected;


    public void SelectTower()
    {
        selected.pool = towerPool;
    }
}
