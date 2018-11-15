using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] int count;

    [SerializeField] Text countLabel;

    void Update()
    {
        Vector3 targetPos = Vector3.MoveTowards(transform.position, state == PlayerState.Down ? m_DownPosition : m_UpPosition, speed * Time.deltaTime);

        transform.position = targetPos;
    }

    public void Move(PlayerState state)
    {
        if (this.state == PlayerState.Down && state == PlayerState.Up)
        {
            count++;

            countLabel.text = count.ToString("D3");
        }

        this.state = state;


    }

}
