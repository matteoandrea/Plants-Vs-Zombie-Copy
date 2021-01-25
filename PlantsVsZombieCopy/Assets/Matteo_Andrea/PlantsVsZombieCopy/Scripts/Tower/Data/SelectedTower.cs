using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectedTower", menuName = "Tower/ TowerSelected")]
public class SelectedTower : ScriptableObject
{
    public Pool pool;


    private void OnEnable()
    {
        pool = null;
    }
}
