using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private PlayerType m_Player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<BallMovement>(out var b))
            ScoreManager.Ins.OnScore(m_Player);
    }
}
