using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartConfetti : MonoBehaviour
{
    private ParticleSystem finalConfetti;

    // Start is called before the first frame update
    void OnEnable()
    {
        GameManager.onChangeGameState += LetItRain;
    }

    void OnDisable()
    {
        GameManager.onChangeGameState -= LetItRain;
    }

    void Awake()
    {
        finalConfetti = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void LetItRain()
    {
        finalConfetti.Play();
    }
}
