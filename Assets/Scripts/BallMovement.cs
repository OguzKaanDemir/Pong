using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private float m_StartSpeed;
    [SerializeField] private float m_ExtraSpeed;
    [SerializeField] private float m_MaxExtraSpeed;
    [SerializeField] private float m_StartDelay;

    private PlayerController m_LastPlayer;

    private int m_HitCounter;
    private Rigidbody2D m_Rb;
    private Vector3 m_StartPosition;

    private void Awake()
    {
        m_Rb = GetComponent<Rigidbody2D>();
        m_StartPosition = this.transform.position;
        GameManager.Ins.onGameStart += ResetBall;
        GameManager.Ins.onNewRound += ResetBall;
        GameManager.Ins.onScore += StopBall;
        GameManager.Ins.onGameFinish += StopBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var p))
        {
            ContactPoint2D[] contacts = collision.contacts;
            var contactPoint = contacts[0].point;
            var localContactY = collision.collider.transform.InverseTransformPoint(contactPoint).y;
            var r = Random.Range(0, 2);
            localContactY += r == 1 ? 0.05f : -0.05f;

            Move(new Vector2(p.ballXDirection, localContactY * 2));
            m_LastPlayer = p;
            m_HitCounter++;
        }
    }

    public void Move(Vector2 direction)
    {
        direction = direction.normalized;
        var ballSpeed = Mathf.Clamp(m_StartSpeed + m_HitCounter * m_ExtraSpeed, m_StartSpeed, m_MaxExtraSpeed);
        m_Rb.velocity = direction * ballSpeed;
    }

    public void ResetBall()
        => StartCoroutine(ResetCoroutine());

    public PlayerController GetLastPlayer()
        => m_LastPlayer;

    private IEnumerator ResetCoroutine()
    {
        this.transform.position = m_StartPosition;
        m_HitCounter = 0;

        yield return new WaitForSeconds(m_StartDelay);
        m_Rb.isKinematic = false;
        Move(new Vector2(Random.Range(0, 2) == 1 ? 1 : -1, 0));
    }

    private void StopBall()
    {
        m_Rb.isKinematic = true;
        m_Rb.velocity = Vector3.zero;
    }
}
