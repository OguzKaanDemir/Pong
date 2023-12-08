using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MatchDataUIItem : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Player1NameText;
    [SerializeField] private TMP_Text m_Player1ScoreText;
    [SerializeField] private TMP_Text m_Player2NameText;
    [SerializeField] private TMP_Text m_Player2ScoreText;

    public void SetItem(string p1Name, int p1Score, string p2Name, int p2Score)
    {
        m_Player1NameText.text = p1Name;
        m_Player1ScoreText.text = p1Score + "";
        m_Player2NameText.text = p2Name;
        m_Player2ScoreText.text = p2Score + "";
    }
}
