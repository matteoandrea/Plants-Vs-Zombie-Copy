using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public List<ZombieData> enemy = new List<ZombieData>();
    public List<float> delay = new List<float>();
    public List<GameObject> nodes = new List<GameObject>();

    private List<Transform> spawnNode = new List<Transform>();

    private int _index;


    private void OnEnable()
    {
        foreach (var item in nodes)
        {
            var e = item.transform.GetChild(0).transform;
            spawnNode.Add(e);
        }
    }

    private void Start()
    {
        StartCoroutine(WaitToSpawn());
    }

    IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(delay[_index]);

        Spawn();
        _index++;

        if(_index <= enemy.Count)        
            StartCoroutine(WaitToSpawn());
    }

    private void Spawn()
    {
        var r = Random.Range(0, nodes.Count);

        enemy[_index].pool.GetPool(spawnNode[r], spawnNode[r].rotation);
    }

}
