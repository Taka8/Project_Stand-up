using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] PlayerMover m_Mover;
    [SerializeField] float m_Threshold = 0.2f;

	void Start () {
		
	}
	
	void Update () {

        float h = Input.GetAxis("Vertical");
        
        if(m_Threshold < h)
        {
            m_Mover.Move(PlayerState.Up);
        }
        else if(h < -m_Threshold)
        {
            m_Mover.Move(PlayerState.Down);
        }

	}

}
