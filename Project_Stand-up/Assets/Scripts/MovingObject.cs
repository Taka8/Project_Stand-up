using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    [SerializeField] Vector3 moveSpeed = new Vector3(0, 0, -5);

	void Update () {
        transform.Translate(moveSpeed * Time.deltaTime);
	}

}
