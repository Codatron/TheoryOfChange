using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public delegate void OnStartScreenTextComplete();

public class UiManager : MonoBehaviour
{
    public static OnStartScreenTextComplete onStartScreenTextComplete;
    public GameObject startText;
    public GameObject endText;
    public Button startButton;
    public GameObject quitButton;
    public GameManager gameManagerRef;

    private string startTextString1 = "Click and drag the items into the donation box...";
    private string startTextString2 = "...and see the changes your contributions can make!";

    private string endTextString1 = "Wow! Your donations have really made a change";
    private string endTextString2 = "Thank you!";

    private void OnEnable()
    {
        GameManager.onChangeGameState += HideStartText;
        GameManager.onChangeGameState += DisplayEndText;
    }

    private void OnDisable()
    {
        GameManager.onChangeGameState -= HideStartText;
        GameManager.onChangeGameState -= DisplayEndText;
    }

    void Start()
    {
        DisplayStartText();
    }

    IEnumerator FadeInText()
    {
        float duration = 1.0f;
        float timer = 0.0f;

        if (gameManagerRef.GetItemsDonated() < 10)
        {
            startText.GetComponent<TMP_Text>().text = startTextString1;
        }
        else
        {
            endText.GetComponent<TMP_Text>().text = endTextString1;
        }

        while (timer < duration)
        {
            float alphaValue = Mathf.Lerp(0.0f, 1.0f, timer / duration);
            startText.GetComponent<TMP_Text>().color = new Color(1, 1, 1, alphaValue);
            endText.GetComponent<TMP_Text>().color = new Color(1, 1, 1, alphaValue);
            timer += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(2.0f);
        
        StartCoroutine(nameof(FadeOutText));

        yield return new WaitForSeconds(1.0f);

        timer = 0.0f;

        if (gameManagerRef.GetItemsDonated() < 10)
        {
            startText.GetComponent<TMP_Text>().text = startTextString2;
        }
        else
        {
            endText.GetComponent<TMP_Text>().text = endTextString2;
        }

        while (timer < duration)
        {
            float alphaValue = Mathf.Lerp(0.0f, 1.0f, timer / duration);
            startText.GetComponent<TMP_Text>().color = new Color(1, 1, 1, alphaValue);
            endText.GetComponent<TMP_Text>().color = new Color(1, 1, 1, alphaValue);
            timer += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(2.0f);
        
        StartCoroutine(nameof(FadeOutText));

        yield return new WaitForSeconds(1.667f);

        HideStartText();

        if (gameManagerRef.GetItemsDonated() < 10)
        {
            onStartScreenTextComplete?.Invoke(); // Called in GameManager
        }
        else 
        {
            HideEndText();
            DisplayButton();
        }

        yield break;
    }

    IEnumerator FadeOutText()
    {
        float duration = 1.0f;
        float timer = 0.0f;

        while (timer < duration)
        {
            float alphaValue = Mathf.Lerp(1.0f, 0.0f, timer / duration);
            startText.GetComponent<TMP_Text>().color = new Color(1, 1, 1, alphaValue);
            endText.GetComponent<TMP_Text>().color = new Color(1, 1, 1, alphaValue);
            timer += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    void DisplayStartText()
    {
        StartCoroutine(nameof(FadeInText));
        startText.SetActive(true);
    }

    void HideStartText()
    {
        startText.SetActive(false);
    }

    void DisplayEndText()
    {
        StartCoroutine(nameof(FadeInText));
        endText.SetActive(true);  
    }

    void HideEndText()
    {
        endText.SetActive(false);
    }

    void DisplayButton()
    {
        quitButton.SetActive(true);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
