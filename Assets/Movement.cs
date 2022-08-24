using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameManager gameManagerRef;

    private float sinCenterY;
    [SerializeField]
    private float timer;
    [SerializeField]
    private float frequency;
    [SerializeField]
    private float amplitude = 0.75f;
    [SerializeField]
    private float speed;

    private Item itemRef;
    private bool hasSpawnedOnLeft;
    Vector3 startPosition;

    void Awake()
    {
        itemRef = GetComponent<Item>();   
    }

    void Start()
    {
        sinCenterY = transform.position.y;

        if (transform.position.x == -9.0f)
        {
            hasSpawnedOnLeft = true;
        }
        else if (transform.position.x == 9.0f)
        {
            hasSpawnedOnLeft = false;
        }

        float randomFrequency = Random.Range(1.0f, 3.0f);
        frequency = randomFrequency;

        float randomSpeed = Random.Range(2.25f, 3.25f);
        speed = randomSpeed;

        float randomAmplitude = Random.Range(0.70f, 0.85f);
        amplitude = randomAmplitude;
    }

    void Update()
    {
        if (!itemRef.isGrabbed)
        {
            Vector3 position = transform.position;

            if (hasSpawnedOnLeft)
            {
                position.x += speed * Time.deltaTime;
            }
            else if (!hasSpawnedOnLeft)
            {
                position.x -= speed * Time.deltaTime;
            }

            float sin = Mathf.Sin(position.x * frequency) * amplitude;
            position.y = sinCenterY + sin;

            transform.position = position;
        }
    }
}
