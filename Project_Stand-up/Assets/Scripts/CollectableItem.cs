using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollectableItem : MonoBehaviour, ICollectable {

    [SerializeField] int point = 100;
    [SerializeField] float lifeTime = 15f;

    void Reset()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void Modify()
    {
        ScoreManger.AddScore(point);

        Destroy(gameObject);
    }

}
