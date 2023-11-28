using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool m_CanMove;
    public bool CanMove
    {
        get => m_CanMove;
        set => m_CanMove = value;
    }

    [SerializeField] private KeyCode m_UpMovementKey;
    [SerializeField] private KeyCode m_DownMovementKey;
    [SerializeField] private float m_Speed;

    private bool m_IsUpPressed
    {
        get => Input.GetKey(m_UpMovementKey);
    }

    private bool m_IsDownPressed
    {
        get => Input.GetKey(m_DownMovementKey);
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (!CanMove) return;
        HandleMovement();
    }

    public void Init()
    {
        CanMove = true;
    }

    private void HandleMovement()
    {
        if (m_IsUpPressed)
            Move(true);
        else if (m_IsDownPressed)
            Move(false);
    }

    private void Move(bool isUp)
    {
        var newPos = this.transform.position;
        if (isUp)
            newPos.y += m_Speed * Time.deltaTime;
        else
            newPos.y -= m_Speed * Time.deltaTime;

        var limit = GameManager.Ins.GetArenaLimit;
        newPos.y = Mathf.Clamp(newPos.y, limit.x, limit.y);
        this.transform.position = newPos;
    }
}
