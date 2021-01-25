using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool isAvailable = true;

    [SerializeField] private Transform _spawn;
    [SerializeField] private Renderer _render;
    [SerializeField] private Material _changeMaterial;
    private Material startMaterial;



    private void Start()
    {
        startMaterial = _render.material;
    }

    public void BuildTower(SelectedTower tower)
    {
        isAvailable = false;
        tower.pool.GetPool(_spawn, _spawn.rotation);
    }

    public void OnNode()
    {
        _render.material = _changeMaterial;
    }


    public void OffNode()
    {
        _render.material = startMaterial;
    }

    private void OnMouseEnter()
    {
        OnNode();
    }

    private void OnMouseExit()
    {
        OffNode();
    }
}
