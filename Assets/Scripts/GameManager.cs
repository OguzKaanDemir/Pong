using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] private Vector2 m_ArenaLimit;
    public Vector2 GetArenaLimit => m_ArenaLimit;

}
