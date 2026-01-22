using UnityEngine;

[RequireComponent(typeof(MeshRenderer),typeof(MeshFilter))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float speed;
    private MeshRenderer meshRenderer;

    private bool isCanMove;

    private GameManager gameManager;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        if (gameManager == null)
            gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Start()
    {
        isCanMove = false;
    }

    void Update()
    {
        if (!isCanMove) return;
        meshRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
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
        isCanMove = true;
    }
}
