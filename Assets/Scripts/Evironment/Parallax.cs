using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (gameManager == null)
            gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnEnable()
    {
        if (gameManager != null)
            gameManager.OnPlay += Play;
    }

    private void OnDisable()
    {
        if (gameManager != null)
            gameManager.OnPlay -= Play;
    }

    private void Play()
    {
        rb.linearVelocity = new Vector2(-speed, 0);
    }
}
