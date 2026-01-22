using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody2D rb;
    private Animator animator;

    [Header("AnimationWhenDie")]
    [SerializeField] private float knockBack;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        rb = GetComponentInParent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerController.OnJump += JumpAnimation;
        playerController.OnDie += DeathAnimation;
    }

    private void OnDisable()
    {
        playerController.OnJump -= JumpAnimation;
        playerController.OnDie -= DeathAnimation;
    }

    private void DeathAnimation()
    {
        animator.SetTrigger("IsDeath");
        rb.linearVelocity = new Vector2(-knockBack, 0);
    }

    private void JumpAnimation()
    {
        animator.SetTrigger("OnJump");
    }
}
