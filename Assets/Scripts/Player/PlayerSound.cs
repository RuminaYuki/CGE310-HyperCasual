using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSound : MonoBehaviour
{
    //event reference
    private PlayerController playerController;
    private AudioSource audioSource;

    [Header("SoundOnJump")]
    [SerializeField] private AudioClip[] soundOnJump;

    [Header("SoundWhenDeath")]
    [SerializeField] private AudioClip soundWhenDeath;

    private int lastIndex = -1;
    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        playerController.OnJump += SoundOnJump;
        playerController.OnDie += WhenDeath;
    }

    private void OnDisable()
    {
        playerController.OnJump -= SoundOnJump;
        playerController.OnDie -= WhenDeath;
    }

    private void SoundOnJump()
    {
        if (soundOnJump.Length == 0) return;
        int r = Random.Range(0, soundOnJump.Length);

        if (r == lastIndex && soundOnJump.Length > 1)
            r = (r + 1) % soundOnJump.Length;

        lastIndex = r;

        audioSource.PlayOneShot(soundOnJump[r]);

    }

    private void WhenDeath()
    {
        if (soundWhenDeath != null)
            audioSource.PlayOneShot(soundWhenDeath);
    }
}
