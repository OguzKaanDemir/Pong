using UnityEngine;

public class BoostSpeed : Boost
{
    [SerializeField] private float m_TargetSpeed;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BallMovement>(out var b))
            DoAction(b);
    }

    public override void DoAction(BallMovement ball)
    {
        base.DoAction(ball);
        ball.GetLastPlayer().SetSpeed(m_TargetSpeed, duration);
    }
}
