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

    [Header("Pacing Game")]
    [SerializeField] private float maxPace = 10;
    [SerializeField] private float basePace = 0.01f;
    private float current;
    public event Action<float> OnPacing;

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

        if (CurrentState == GameState.GamePlay)
        {
            CalculatePacing();
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

    private void CalculatePacing()
    {
        current += basePace * Time.deltaTime;
        current = Mathf.Min(current, maxPace);
        OnPacing?.Invoke(current);

    }
}
