using UnityEngine;

public class BoostScale : Boost
{
    [SerializeField] private float m_TargetScale;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BallMovement>(out var b))
            DoAction(b);
    }

    public override void DoAction(BallMovement ball)
    {
        base.DoAction(ball);
        ball.GetLastPlayer().SetScale(m_TargetScale, duration);
    }
}
