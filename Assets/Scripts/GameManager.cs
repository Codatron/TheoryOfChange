using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject flowerPrefab;
    public Collider2D donationBox;

    private int itemsDonated;
    [SerializeField] int randomSpawnPoint;


    // ToDo
    // - animate flowers
    // - time delay for new item to appear
    // - audio
    // - make items float/hover in the air
    // - particle effects

    private void OnEnable()
    {
        CollectItem.onItemDonated += AddItemsDonated;
        CollectItem.onItemDonated += SpawnItem;
        CollectItem.onItemDonated += SpawnFlower;
    }

    private void OnDisable()
    {
        CollectItem.onItemDonated -= AddItemsDonated;
        CollectItem.onItemDonated -= SpawnItem;
        CollectItem.onItemDonated -= SpawnFlower;
    }

    void Start()
    {
        SpawnItem();
        itemsDonated = 0;
    }

    void SpawnItem()
    {
        var spawnPointLeft = RandomSpawnPosition(-9.0f, -9.0f, 2.5f, 3.25f);
        var spawnPointRight = RandomSpawnPosition(9.0f, 9.0f, 2.5f, 3.25f);

        randomSpawnPoint = Random.Range(0, 2);
        
        if (randomSpawnPoint == 0)
        {
            var itemClone = Instantiate(itemPrefab, spawnPointLeft, Quaternion.identity);
        }
        else if (randomSpawnPoint == 1)
        {
            var itemClone = Instantiate(itemPrefab, spawnPointRight, Quaternion.identity);
        }
    }

    private void SpawnFlower()
    {
        for (int i = 0; i < itemsDonated; i++)
        {
            var spawnPosition = RandomSpawnPosition(-8.0f, 8.0f, 0.85f, -4.0f);
            bool canSpawnHere = true;
            var tries = 0;

            do
            {
                spawnPosition = RandomSpawnPosition(-8.0f, 8.0f, 0.85f, -4.0f);

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

            var flowerClone = Instantiate(flowerPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 RandomSpawnPosition(float xPosMin, float xPosMax, float yPosmin, float yPosMax)
    {
        var randomPositionX = Random.Range(xPosMin, xPosMax);
        var randomPositionY = Random.Range(yPosmin, yPosMax);

        return new Vector3(randomPositionX, randomPositionY, 0.0f);
    }

    void AddItemsDonated()
    {
        itemsDonated++;
    }
}