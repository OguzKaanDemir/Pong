using UnityEngine;
using System.Collections.Generic;

public class BoostSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_BoostPrefabs;
    [SerializeField] private Vector2 m_PositiveBoostArenaLimit;
    [SerializeField] private float m_SpawnDuration;

    private void Awake()
    {
        GameManager.Ins.onGameStart += StartSpawn;
        GameManager.Ins.onScore += StopSpawn;
        GameManager.Ins.onNewRound += StartSpawn;
        GameManager.Ins.onGameFinish += StopSpawn;
    }

    public void StartSpawn()
    {
        StopSpawn();
        Invoke(nameof(Spawn), m_SpawnDuration);
    }

    private void StopSpawn()
        => CancelInvoke(nameof(Spawn));

    private void Spawn()
    {
        var rIndex = Random.Range(0, m_BoostPrefabs.Count);

        var rPos = Vector3.zero;
        rPos.x = Random.Range(-m_PositiveBoostArenaLimit.x, m_PositiveBoostArenaLimit.x);
        rPos.y = Random.Range(-m_PositiveBoostArenaLimit.y, m_PositiveBoostArenaLimit.y);
        var boost = Instantiate(m_BoostPrefabs[rIndex], rPos, Quaternion.identity);
    }
}
