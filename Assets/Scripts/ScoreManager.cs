using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _ins;
    public static ScoreManager Ins
    {
        get
        {
            if (!_ins)
                _ins = FindObjectOfType<ScoreManager>();
            return _ins;
        }
    }

    public (int player1Score, int player2Score) GetScores
        => (m_Player1Score, m_Player2Score);

    [SerializeField] private int m_MaxScore;
    [SerializeField] private TMP_Text m_Player1ScoreText;
    [SerializeField] private TMP_Text m_Player2ScoreText;

    private int m_Player1Score;
    private int m_Player2Score;

    public void OnScore(PlayerType player)
    {
        SetScore(player);
        GameManager.Ins.onScore?.Invoke();
    }
    
    private void SetScore(PlayerType player)
    {
        switch (player)
        {
            case PlayerType.Player1:
                m_Player1Score++;
                SetText(m_Player1ScoreText, m_Player1Score);
                break;

            case PlayerType.Player2:
                m_Player2Score++;
                SetText(m_Player2ScoreText, m_Player2Score);
                break;
        }

        if(m_Player1Score >= m_MaxScore || m_Player2Score >= m_MaxScore)
            GameManager.Ins.onGameFinish?.Invoke();
        else
            Invoke(nameof(OnNewRound), 1.5f);
    }

    private void SetText(TMP_Text text, int score)
    {
        text.text = score.ToString();
    }

    private void OnNewRound()
    {
        GameManager.Ins.onNewRound?.Invoke();
    }
}
