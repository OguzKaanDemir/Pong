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
    [SerializeField] private GameObject m_PanelsPArent;

    [SerializeField] private Vector2 m_ArenaLimit;
    public Vector2 GetArenaLimit => m_ArenaLimit;

    private void Start()
    {
        onGameFinish += OpenPanelsParent;
        onGameStart?.Invoke();
    }

    private void OpenPanelsParent()
        => m_PanelsPArent.SetActive(true);

}
