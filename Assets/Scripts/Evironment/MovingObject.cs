using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingObject : MonoBehaviour
{
    [SerializeField] private float Speed;
    private float currentSpeed;
    private Rigidbody2D rb;

    private GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (gameManager == null)
            gameManager = FindAnyObjectByType<GameManager>();
    }
    private void Start()
    {
        currentSpeed = Speed;
    }
    private void OnEnable()
    {
        if (gameManager != null)
        {
            gameManager.OnPlay += Play;
            gameManager.OnPacing += PacingChange;
        }    
    }

    private void OnDisable()
    {
        if (gameManager != null)
        {
            gameManager.OnPlay -= Play;
            gameManager.OnPacing -= PacingChange;
        } 
    }

    private void Play()
    {
        rb.linearVelocity = new Vector2(-currentSpeed, 0);
    }
    private void PacingChange(float pace)
    {
        currentSpeed = Speed + pace;
        rb.linearVelocity = new Vector2(-currentSpeed, 0);
    }
}
