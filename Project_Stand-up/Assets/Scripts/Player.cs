using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] PlayerMover m_Mover;
    [SerializeField] float m_Threshold = 0.2f;
    [SerializeField] CustomInput input;

	void Start () {
		
	}
	
	void Update () {

        float h = Input.GetAxis("Vertical");

        if (input.isSitdown == false)
        {
            m_Mover.Move(PlayerState.Up);
        }
        else
        {
            m_Mover.Move(PlayerState.Down);
        }

	}

    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<ICollectable>().Modify();
    }

}
