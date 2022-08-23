using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject flowerPrefab;
    public LayerMask filterMask;
    public Collider2D[] colliders;
    public float radius = 3.0f;
    
    private int itemsDonated;


    // ToDo
    // - Do not spawn objects on donation box
    // - animate flowers
    // - time delay for new item to appear
    // - audio
    // - import new flowers that are the same size
    // - make items float/hover in the air
    // - particle effects

    private void Awake()
    {
    }

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

    private void Start()
    {
        SpawnItem();
        itemsDonated = 0;
    }

    private void Update()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, radius);
    }

    void SpawnItem()
    {
        var itemClone = Instantiate(itemPrefab, RandomSpawnPosition(-4.0f, 4.0f, 1.5f, 4.0f), Quaternion.identity);
    }

    private void SpawnFlower()
    {
        for (int i = 0; i < itemsDonated; i++)
        {
            if (colliders != null)
            {
                var flowerClone = Instantiate(flowerPrefab, RandomSpawnPosition(-4.0f, 4.0f, 0.85f, -4.0f), Quaternion.identity);
            }
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