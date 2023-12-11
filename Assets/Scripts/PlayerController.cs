using DG.Tweening;
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

    public int ballXDirection;
    [SerializeField] private KeyCode m_UpMovementKey;
    [SerializeField] private KeyCode m_DownMovementKey;
    [SerializeField] private float m_Speed;

    private float m_StartScale;
    private float m_StartSpeed;
    private bool m_IsUpPressed
    {
        get => Input.GetKey(m_UpMovementKey);
    }
    private bool m_IsDownPressed
    {
        get => Input.GetKey(m_DownMovementKey);
    }

    private void Awake()
    {
        GameManager.Ins.onGameStart += ResetPlayer;
        GameManager.Ins.onNewRound += ResetPlayer;
        GameManager.Ins.onGameFinish += StopPlayer;

        m_StartScale = this.transform.localScale.y;
        m_StartSpeed = m_Speed;
    }

    private void Update()
    {
        if (!CanMove) return;
        HandleMovement();
    }

    public void ResetPlayer()
    {
        CanMove = true;
    }

    public void SetSpeed(float newSpeed, float duration)
    {
        StartCoroutine(SpeedCoroutine(newSpeed, duration));
    }

    private IEnumerator SpeedCoroutine(float newSpeed, float duration)
    {
        DOTween.To(()=>m_Speed, x => m_Speed = x, newSpeed, 1f);

        yield return new WaitForSeconds(duration);

        DOTween.To(() => m_Speed, x => m_Speed = x, m_StartSpeed, 1f);
    }

    public void SetScale(float newScale, float duration)
    {
        StartCoroutine(ScaleCoroutine(newScale, duration));
    }

    private IEnumerator ScaleCoroutine(float newScale, float duration)
    {
        this.transform.DOScaleY(newScale, 1f);

        yield return new WaitForSeconds(duration);

        this.transform.DOScaleY(m_StartScale, 1f);
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
        var currentScale = this.transform.localScale.y;
        var roundedNumber = System.Math.Round((double)(currentScale - m_StartScale), 2) * 10;
        limit.x += (float)roundedNumber * 0.05f;
        limit.y -= (float)roundedNumber * 0.05f;
        newPos.y = Mathf.Clamp(newPos.y, limit.x, limit.y);
        this.transform.position = newPos;
    }

    private void StopPlayer()
    {
        CanMove = false;
    }
}
