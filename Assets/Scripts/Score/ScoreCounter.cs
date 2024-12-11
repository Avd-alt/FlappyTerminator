using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    public int Score { get; private set; }

    public event Action ScoreChanged;

    private void Awake()
    {
        Score = 0;
    }

    private void OnEnable()
    {
        _enemySpawner.Killed += AddScore;
    }

    private void OnDisable()
    {
        _enemySpawner.Killed -= AddScore;
    }

    public void Reset()
    {
        Score = 0;
        ScoreChanged?.Invoke();
    }

    private void AddScore()
    {
        Score++;
        ScoreChanged?.Invoke();
    }
}