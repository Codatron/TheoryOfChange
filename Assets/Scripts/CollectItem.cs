using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnItemDonated();

public class CollectItem : MonoBehaviour
{
    public static OnItemDonated onItemDonated;
    public ParticleSystem confetti;
    public AudioSource audioSource;
    public AudioClip cheeringKidsClips;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            onItemDonated?.Invoke(); // Called in GameManager
            confetti.Play();

            float randomPitch = Random.Range(0.7f, 1.0f);
            audioSource.pitch = randomPitch; 
            audioSource.PlayOneShot(cheeringKidsClips);
        }
    }
}
