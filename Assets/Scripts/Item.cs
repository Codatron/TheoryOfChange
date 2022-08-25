using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
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
        //int randomItem = Random.Range(0, clothingItems.Length);
        //spriteRend.sprite = clothingItems[randomItem];
    }

    void Update()
    {
        if (!isGrabbed)
            return;
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
        spriteRend.color = new Color(0.75f, 0.25f, 0.25f, 1.0f);
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
