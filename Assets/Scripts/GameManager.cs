using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager _ins;
    public static GameManager Ins
    {
        get
        {
            if (!_ins)
                _ins = FindObjectOfType<GameManager>();
            return _ins;
        }
    }

    public UnityAction onGameStart;
    public UnityAction onScore;
    public UnityAction onNewRound;
    public UnityAction onGameFinish;

    [SerializeField] private BallMovement m_Ball;
    [SerializeField] private GameObject m_PanelsParent;
    [SerializeField] private GameObject m_EndGamePanel;
    [SerializeField] private GameObject m_StartGamePanel;

    [SerializeField] private Vector2 m_ArenaLimit;
    public Vector2 GetArenaLimit => m_ArenaLimit;

    private void Awake()
    {
        onGameStart += SetOnGameStartPanels;
        onGameFinish += SetOnGameFinishPanels;
    }

    public void StartGame()
    {
        onGameStart?.Invoke();
    }

    private void SetOnGameFinishPanels()
    {
        m_PanelsParent.SetActive(true);
        m_EndGamePanel.SetActive(true);
    }

    private void SetOnGameStartPanels()
    {
        m_StartGamePanel.SetActive(false);
        m_PanelsParent.SetActive(false);
    }
}
