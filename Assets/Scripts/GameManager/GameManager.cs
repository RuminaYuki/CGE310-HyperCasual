using System;
using UnityEngine;

public enum GameState
{
    GameStart,
    GamePlay,
    GameOver
}
public class GameManager : MonoBehaviour
{
    public GameState CurrentState { get; private set; }

    public event Action OnStart;
    public event Action OnPlay;
    public event Action OnOver;

    private PlayerController playerController;

    public bool IsPlaying => CurrentState == GameState.GamePlay;

    private void Awake()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    private void Start()
    {
        SetState(GameState.GameStart);
    }

    private void OnEnable()
    {
        playerController.OnDie += GameOver;
    }

    private void OnDisable()
    {
        playerController.OnDie -= GameOver;
    }
    private void Update()
    {
        if (CurrentState == GameState.GameStart)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                SetState(GameState.GamePlay);
            }
        }
    }
    private void GameOver()
    {
        SetState(GameState.GameOver);
    }

    private void SetState(GameState newState)
    {
        if (CurrentState == newState) return;

        CurrentState = newState;

        switch (CurrentState)
        {
            case GameState.GameStart: OnStart?.Invoke(); break;
            case GameState.GamePlay: OnPlay?.Invoke(); break;
            case GameState.GameOver: OnOver?.Invoke(); break;
        }
    }
}
