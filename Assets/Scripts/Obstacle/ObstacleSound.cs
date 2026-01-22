using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ObstacleSound : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
