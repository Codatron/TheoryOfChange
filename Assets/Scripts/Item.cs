using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isGrabbed = false;

    private new Camera camera;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        camera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        //var randomXPosition = Random.Range(-2.0f, 2.0f);
        //var randomYPosition = Random.Range(0.75f, 1.80f);
        //var randomStartPosition = new Vector3(randomXPosition, randomYPosition, 0.0f);
        //transform.position = randomStartPosition;
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
        spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
    }

    private void OnMouseDrag()
    {
        if (isGrabbed)
            transform.position = MouseWorldPosition();
    }

    private void OnMouseUp()
    {
        isGrabbed = false;
        spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}
