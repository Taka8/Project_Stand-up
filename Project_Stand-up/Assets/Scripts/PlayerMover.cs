using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Down,
    Up
}

public class PlayerMover : MonoBehaviour {

    [SerializeField] Vector3 m_DownPosition;
    [SerializeField] Vector3 m_UpPosition;

    [SerializeField] PlayerState state;

    [SerializeField] float speed = 5f;

    void Update()
    {
        Vector3 targetPos = Vector3.MoveTowards(transform.position, state == PlayerState.Down ? m_DownPosition : m_UpPosition, speed * Time.deltaTime);

        transform.position = targetPos;
    }

    public void Move(PlayerState state)
    {
        this.state = state;
    }

}
