using UnityEngine;

public class ScriptColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float spawnRate = 4f;
    public float columnMin = -2f;
    public float columnMax = 2f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);

    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentColumn = 0;

    private GameManager gameManager;
    private bool isCanSpawn;

    private void Awake()
    {
        if (gameManager == null)
            gameManager = FindAnyObjectByType<GameManager>();
    }

    void Start()
    {
        columns = new GameObject[columnPoolSize];
        isCanSpawn = false;

        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = Instantiate(
                columnPrefab,
                objectPoolPosition,
                Quaternion.identity
            );
        }
    }

    void Update()
    {
        if(!isCanSpawn) return;
        timeSinceLastSpawned += Time.deltaTime;

        if (timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            float spawnYPosition = Random.Range(columnMin, columnMax);

            columns[currentColumn].transform.position =
                new Vector2(spawnXPosition, spawnYPosition);

            currentColumn++;

            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
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

    private void Play()
    {
        isCanSpawn = true;
    }
}

