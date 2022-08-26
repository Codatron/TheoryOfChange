using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    public AudioSource backgroundAudioSource;
    public AudioSource birdsongAudioSource;
    public GameManager gameManager;


    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameState == GameState.GamePause)
        {
            float volumeChange = 0.00125f;
            backgroundAudioSource.volume -= volumeChange;
            birdsongAudioSource.volume -= volumeChange;

            if (backgroundAudioSource.volume < 0.15f)
            {
                backgroundAudioSource.Stop();
                birdsongAudioSource.Stop();
            }
        }
    }
}
