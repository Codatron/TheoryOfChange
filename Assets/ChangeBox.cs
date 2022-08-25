using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBox : MonoBehaviour
{
    public GameObject openBox;
    public GameObject closedBox;
    public AudioSource audioSource;
    public AudioClip boxLidClip;

    private void OnEnable()
    {
        CollectItem.onItemDonated += StartRoutine;    
    }

    private void OnDisable()
    {
        CollectItem.onItemDonated -= StartRoutine;
    }

    void Start()
    {
        openBox.SetActive(true);
        closedBox.SetActive(false);
    }

    IEnumerator OpenCloseDonationBox()
    {
        closedBox.SetActive(true);
        openBox.SetActive(false);
        audioSource.PlayOneShot(boxLidClip);

        yield return new WaitForSeconds(0.667f);

        openBox.SetActive(true);
        closedBox.SetActive(false);

        yield return null;
    }

    void StartRoutine()
    {
        StartCoroutine(nameof(OpenCloseDonationBox));
    }

}
