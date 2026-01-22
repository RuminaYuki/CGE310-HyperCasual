using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private GameManager gameManager;
    private ScoreSystem scoreSystem;

    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        if (gameManager == null)
            gameManager = FindAnyObjectByType<GameManager>();

        if (scoreSystem == null)
            scoreSystem = FindAnyObjectByType<ScoreSystem>();

        textMeshPro = GetComponent<TextMeshProUGUI>();

    }
    void Start()
    {
        textMeshPro.text = "";
    }

    private void OnEnable()
    {
        gameManager.OnPlay += Play;
        scoreSystem.OnScoreChanged += updateScore;
    }

    private void OnDisable()
    {
        gameManager.OnPlay -= Play;
        scoreSystem.OnScoreChanged -= updateScore;
    }

    private void Play()
    {
        textMeshPro.text = "Score : ";
    }

    private void updateScore(int score)
    {
        textMeshPro.text = $"Score : {score.ToString()}";
    }
}
