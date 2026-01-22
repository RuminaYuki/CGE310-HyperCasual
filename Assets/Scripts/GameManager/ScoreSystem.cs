using System;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int Score { get; private set; }
    public event Action<int> OnScoreChanged;

    public void ResetScore()
    {
        Score = 0;
        OnScoreChanged?.Invoke(Score);
    }

    public void Add(int amount)
    {
        Score += amount;
        OnScoreChanged?.Invoke(Score);
    }
}
