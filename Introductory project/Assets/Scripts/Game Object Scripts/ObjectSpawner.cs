using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private int numberSpawns = 0;

    [SerializeField] private Transform spawnPointsParent;
    [SerializeField] private Transform parentForNew;

    [SerializeField] private GameObject prefab;

    private List<Transform> spawnPositions;


    public int NumberSpawns
    {
        get { return numberSpawns; }
    }

    private void Start()
    {
        if (!spawnPointsParent)
            spawnPointsParent = GameObject.FindGameObjectWithTag("SpawnPositions").GetComponent<Transform>();
       
        if(spawnPointsParent)
        {
            spawnPositions = spawnPointsParent.GetComponentsInChildren<Transform>().ToList();
            spawnPositions.RemoveAt(0);

            if (numberSpawns <= 0)
                numberSpawns = spawnPositions.Count;
            else
                numberSpawns = Mathf.Clamp(numberSpawns, 1, spawnPositions.Count);

            Spawn();
        }
    }


    private void Spawn()
    {
        for(int i = 0; i < numberSpawns; i++)
        {
            int index = Random.Range(0, spawnPositions.Count-1);
            Instantiate(prefab, spawnPositions[index].position, Quaternion.identity, parentForNew);

            spawnPositions.RemoveAt(index);
        }
    }
}
