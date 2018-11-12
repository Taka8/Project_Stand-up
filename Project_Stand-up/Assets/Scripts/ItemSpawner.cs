using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField] GameObject waveObject;

    [SerializeField] Transform[] spawnPoints;

    [SerializeField] float duration = 3f;

    [SerializeField] int randomSeed= 0;

    IEnumerator Start()
    {

        Random.InitState(randomSeed);

        while (true)
        {

            int r = Random.Range(0, spawnPoints.Length);

            Instantiate(waveObject, spawnPoints[r].position, Quaternion.identity);

            yield return new WaitForSeconds(duration);
        }

    }

    void Update()
    {

    }

}
