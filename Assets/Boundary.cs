using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnItemDestroyed();

public class Boundary : MonoBehaviour
{
    public static OnItemDestroyed onItemDestroyed;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            onItemDestroyed?.Invoke(); // Called in GameManager
        }
    }
}
