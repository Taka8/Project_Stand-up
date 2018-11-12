using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLandscape : MonoBehaviour {

    [SerializeField] float m_StartPos = 0f;
    [SerializeField] float m_EndPos = 20f;

    [SerializeField] float m_MoveSpeed = 5f;

	void Start () {
		
	}
	
	void Update () {

        Vector3 afterPos = transform.position;

        afterPos.z -= m_MoveSpeed * Time.deltaTime;

        if (afterPos.z < m_StartPos) afterPos.z = m_EndPos;

        transform.position = afterPos;

	}

}
