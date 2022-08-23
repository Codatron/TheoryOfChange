using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnItemDonated();

public class CollectItem : MonoBehaviour
{
    public static OnItemDonated onItemDonated;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            onItemDonated?.Invoke();
        }
    }
}
