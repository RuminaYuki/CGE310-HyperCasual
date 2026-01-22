using UnityEngine;

public class TapToPlayManager : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        if(gameManager == null)
            gameManager = FindAnyObjectByType<GameManager>();
    }
    void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        gameManager.OnPlay += Play;
    }

    private void OnDisable()
    {
        gameManager.OnPlay -= Play;
    }

    private void Play()
    {
        gameObject.SetActive(false);
    }
}
