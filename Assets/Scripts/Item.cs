using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnSuicide();

public class Item : MonoBehaviour
{
    public static OnSuicide onSuicide;
    public bool isGrabbed = false;
    public Sprite[] clothingItems;

    private new Camera camera;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        camera = Camera.main;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        int randomItem = Random.Range(0, clothingItems.Length);
        spriteRend.sprite = clothingItems[randomItem];
    }

    void Update()
    {
        if (!isGrabbed)
            return;

        if (transform.position.x < -10.0f || transform.position.x > 10.0f)
        {
            Destroy(gameObject);
            onSuicide?.Invoke(); // Called in GameManager
        }
    }

    public Vector3 MouseWorldPosition()
    {
        var mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.0f;
        return mousePosition;
    }

    private void OnMouseDown()
    {
        isGrabbed = true;

        Vector3 offset = transform.position - MouseWorldPosition();
        spriteRend.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
    }

    private void OnMouseDrag()
    {
        if (isGrabbed)
            transform.position = MouseWorldPosition();
    }

    private void OnMouseUp()
    {
        isGrabbed = false;
        spriteRend.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}
