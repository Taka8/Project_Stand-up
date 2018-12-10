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

        int counter = 0;

        while (true)
        {

            // int r = Random.Range(0, spawnPoints.Length);
            
            Instantiate(waveObject, spawnPoints[counter].position, Quaternion.identity);

            counter++;
            if (counter > 1) counter = 0;

            yield return new WaitForSeconds(duration);
        }

    }

    void Update()
    {

    }

}
