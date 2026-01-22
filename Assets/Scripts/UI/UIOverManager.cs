using UnityEngine;
using UnityEngine.SceneManagement;

public class UIOverManager : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private GameObject textGroup;

    private void Awake()
    {
        if (gameManager == null)
            gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnEnable()
    {
        if (gameManager != null)
            gameManager.OnOver += Over;
    }

    private void OnDisable()
    {
        if (gameManager != null)
            gameManager.OnOver -= Over;
    }

    private void Over()
    {
        textGroup.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");

        Application.Quit();
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
