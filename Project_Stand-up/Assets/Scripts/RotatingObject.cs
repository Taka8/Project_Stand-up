using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour {

    [SerializeField] float speed = 5f;

    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

}
