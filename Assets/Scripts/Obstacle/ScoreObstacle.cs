using UnityEngine;

public class ScoreObstacle : MonoBehaviour
{
    [SerializeField] private int getScore;
    private ScoreSystem scoretrigger;

    private void Awake()
    {
        scoretrigger = FindAnyObjectByType<ScoreSystem>();

        if (scoretrigger == null)
        {
            Debug.LogError("ScoreSystem not found in scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scoretrigger.Add(getScore);
        }
    }
}
