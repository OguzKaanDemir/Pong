using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] private GameObject m_MatchesPanel;
    [SerializeField] private TMP_InputField m_Player1Field;
    [SerializeField] private Button m_Player1ConfirmButton;

    [SerializeField] private TMP_InputField m_Player2Field;
    [SerializeField] private Button m_Player2ConfirmButton;

    private int m_ConfirmedCount;

    private void Start()
    {
        m_Player1ConfirmButton.onClick.AddListener(() => ConfirmName(m_Player1Field, m_Player1ConfirmButton));
        m_Player2ConfirmButton.onClick.AddListener(() => ConfirmName(m_Player2Field, m_Player2ConfirmButton));
    }

    private void ConfirmName(TMP_InputField nameField, Button button)
    {
        if (!string.IsNullOrEmpty(nameField.text) && nameField.text.Length > 2)
        {
            nameField.interactable = false;
            button.interactable = false;
            m_ConfirmedCount++;

            if (m_ConfirmedCount == 2)
            {
                var scores = ScoreManager.Ins.GetScores;
                DataManager.SaveMatchData(m_Player1Field.text, scores.player1Score, m_Player2Field.text, scores.player2Score);
                m_MatchesPanel.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}
