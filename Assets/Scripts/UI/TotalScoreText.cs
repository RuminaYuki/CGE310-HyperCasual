using TMPro;
using UnityEngine;

public class TotalScoreText : MonoBehaviour
{
    private ScoreSystem scoreSystem;
    private TextMeshProUGUI textMeshPro;

    [SerializeField] private string text;

    private void Awake()
    {
        if (scoreSystem == null)
            scoreSystem = FindAnyObjectByType<ScoreSystem>();

        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        textMeshPro.text = $"{text} : {scoreSystem.Score}";
    }
}
