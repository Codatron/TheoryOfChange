using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void OnChangeGameState();

public enum GameState
{
    GameOn,
    GamePause
}

public class GameManager : MonoBehaviour
{
    //public GameObject itemPrefab;
    public GameObject[] itemPrefabs;
    public GameObject flowerPrefab;
    public GameObject[] flowerPrefabs;
    public Collider2D donationBox;
    public static OnChangeGameState onChangeGameState;
    public AudioSource audioSource;
    public AudioClip finalCheerClip;
    public AudioClip flowerPop;

    private int itemsDonated;
    private int itemsMultiplier;
    [SerializeField] int randomSpawnPoint;

    public GameState gameState;

    // ToDo

    // - adjust collision boxes on sprites

    private void OnEnable()
    {
        CollectItem.onItemDonated += AddItemsDonated;
        CollectItem.onItemDonated += SpawnItem;
        CollectItem.onItemDonated += SpawnFlower;
        Boundary.onItemDestroyed += SpawnItem;
        UiManager.onStartScreenTextComplete += StartGame;
    }

    private void OnDisable()
    {
        CollectItem.onItemDonated -= AddItemsDonated;
        CollectItem.onItemDonated -= SpawnItem;
        CollectItem.onItemDonated -= SpawnFlower;
        Boundary.onItemDestroyed -= SpawnItem;
        UiManager.onStartScreenTextComplete -= StartGame;
    }

    void Start()
    {
        //gameState = GameState.GamePause;
        SpawnItem();
        itemsDonated = 0;
        itemsMultiplier = 0;
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(0.667f);

        
        if (gameState != GameState.GamePause)
        {
            var spawnPointLeft = RandomSpawnPosition(-9.0f, -9.0f, 2.5f, 3.15f);
            var spawnPointRight = RandomSpawnPosition(9.0f, 9.0f, 2.5f, 3.15f);

            randomSpawnPoint = Random.Range(0, 2);

            int randomItem = Random.Range(0, itemPrefabs.Length);

            if (randomSpawnPoint == 0)
            {
                var itemClone = Instantiate(itemPrefabs[randomItem], spawnPointLeft, Quaternion.identity);
            }
            else if (randomSpawnPoint == 1)
            {
                var itemClone = Instantiate(itemPrefabs[randomItem], spawnPointRight, Quaternion.identity);
            }
        }
    }

    void SpawnItem()
    {
        StartCoroutine(nameof(SpawnDelay));
    }

    private void SpawnFlower()
    {
        for (int i = 0; i < itemsMultiplier; i++)
        {
            var spawnPosition = RandomSpawnPosition(-9.5f, 9.5f, 0.85f, -6.5f);
            bool canSpawnHere = true;
            var tries = 0;

            do
            {
                spawnPosition = RandomSpawnPosition(-9.5f, 9.5f, 0.85f, -6.5f);

                //canSpawnHere = true;

                if (donationBox.bounds.Contains(spawnPosition))
                {
                    canSpawnHere = false;
                }

                tries++;

                if (tries > 50)
                {
                    break;
                }
            }
            while (!canSpawnHere);

            int randomFlower = Random.Range(0, flowerPrefabs.Length);
            var flowerClone = Instantiate(flowerPrefabs[randomFlower], spawnPosition, Quaternion.identity);

            float randomPitch = Random.Range(0.7f, 1.0f);
            audioSource.pitch = randomPitch;
            audioSource.PlayOneShot(flowerPop);
        }
    }

    private Vector3 RandomSpawnPosition(float xPosMin, float xPosMax, float yPosmin, float yPosMax)
    {
        var randomPositionX = Random.Range(xPosMin, xPosMax);
        var randomPositionY = Random.Range(yPosmin, yPosMax);

        return new Vector3(randomPositionX, randomPositionY, 0.0f);
    }

    public int GetItemsDonated()
    {
        return itemsDonated;
    }

    void AddItemsDonated()
    {
        if (itemsMultiplier > 0)
        {
            itemsMultiplier *= 2;
            itemsMultiplier++;
        }
        else
        {
            itemsMultiplier++;
        }

        itemsDonated++;

        if (itemsDonated == 10)
        {
            gameState = GameState.GamePause;
            onChangeGameState?.Invoke(); // Called in UiManager
            audioSource.PlayOneShot(finalCheerClip);
        }
    }

    void StartGame()
    {
        gameState = GameState.GameOn;
        StartCoroutine(nameof(SpawnDelay));
    }
}