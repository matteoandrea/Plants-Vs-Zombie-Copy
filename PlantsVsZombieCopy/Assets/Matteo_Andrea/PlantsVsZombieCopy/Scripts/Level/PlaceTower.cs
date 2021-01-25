using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public InputReader input;
    [SerializeField]private SelectedTower towerSeleted;
    [SerializeField] private LayerMask nodeLayer;
    [SerializeField] private Tower tower;

    private Vector2 _mousePos;

    private Node currentNode;




    private void OnEnable()
    {
        input.InteractEvent += PlaceCurrentTower;
        input.MousePositionEvent += TrackMousePos;
        input.CancelInteractEvent += CancelTower;
    }

    private void OnDisable()
    {
        input.InteractEvent -= PlaceCurrentTower;
        input.MousePositionEvent -= TrackMousePos;
        input.CancelInteractEvent -= CancelTower;
    }






    private void FixedUpdate()
    {
        SelectNode();       
    }



    private void SelectNode()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(_mousePos);

        if (Physics.Raycast(ray, out hit, 100, nodeLayer))
        {
            var n = hit.collider.gameObject.GetComponent<Node>();

            if (n != null)
            {
                if(currentNode != null)                
                    currentNode.OffNode();
                
                currentNode = n;
                currentNode.OnNode();
            }
        }
        else 
        {
            if (currentNode != null)
            {
                currentNode.OffNode();
                currentNode = null;
            }
        }
    }


    private void PlaceCurrentTower()
    {
        if (towerSeleted.pool == null || currentNode == null)
            return;
        if (!currentNode.isAvailable)
            return;
       
        currentNode.BuildTower(towerSeleted);
        towerSeleted.pool = null;         
    }

    private void TrackMousePos(Vector2 pos)
    {
        _mousePos = pos;
    }

    private void CancelTower()
    {
        if(towerSeleted.pool != null)
            towerSeleted.pool = null;
    }   
}
