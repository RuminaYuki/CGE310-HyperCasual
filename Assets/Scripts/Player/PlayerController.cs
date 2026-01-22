using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    public event Action OnJump;
    public event Action OnDie;

    private bool isDeath;
    private bool isCanMove;

    private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] private float jumpforce = 5f;
    [SerializeField] private float gravity = 1f;

    private GameManager gameManager;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (gameManager == null)
            gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Start()
    {
        isDeath = false;
        isCanMove = false;
        rb.gravityScale = 0;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isDeath)
        {
            Jump();
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !isDeath)
        {
            Death();
        }
    }

    private void Jump()
    {
        if (!isCanMove) return;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);

        OnJump?.Invoke();
    }

    private void Death()
    {
        isDeath = true;
        OnDie?.Invoke();
    }

    private void Play()
    {
        rb.gravityScale = gravity;
        isCanMove = true;
    }
}
