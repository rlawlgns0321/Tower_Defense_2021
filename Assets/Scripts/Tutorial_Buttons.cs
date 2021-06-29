using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_Buttons : MonoBehaviour
{
    public string BackToMainmenu = "MainMenu";
    public GameObject Tutorial_0;
    public GameObject Tutorial_1;
    public GameObject Tutorial_2;
    public GameObject Tutorial_3;
    public GameObject Tutorial_4;
    public GameObject nextButton;

    public void BackButton()
    {
        if (Tutorial_0.activeSelf)
        {
            StartCoroutine(loadScene(BackToMainmenu));
            Time.timeScale = 1f;
        }
        else if (Tutorial_1.activeSelf)
        {
            Tutorial_0.gameObject.SetActive(true);
            Tutorial_1.gameObject.SetActive(false);
        }
        else if (Tutorial_2.activeSelf)
        {
            Tutorial_1.gameObject.SetActive(true);
            Tutorial_2.gameObject.SetActive(false);
        }
        else if (Tutorial_3.activeSelf)
        {
            Tutorial_2.gameObject.SetActive(true);
            Tutorial_3.gameObject.SetActive(false);
        }
        else if (Tutorial_4.activeSelf)
        {
            Tutorial_3.gameObject.SetActive(true);
            Tutorial_4.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);
        }
    }

    public void NextButton()
    {
        if (Tutorial_0.activeSelf)
        {
            Tutorial_0.gameObject.SetActive(false);
            Tutorial_1.gameObject.SetActive(true);
        }
        if (Tutorial_1.activeSelf)
        {
            Tutorial_1.gameObject.SetActive(false);
            Tutorial_2.gameObject.SetActive(true);
        }
        else if (Tutorial_2.activeSelf)
        {
            Tutorial_2.gameObject.SetActive(false);
            Tutorial_3.gameObject.SetActive(true);
        }
        else if (Tutorial_3.activeSelf)
        {
            Tutorial_3.gameObject.SetActive(false);
            Tutorial_4.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(false);
        }
    }

    IEnumerator loadScene(string sceneName)
    {
        AsyncOperation OP = SceneManager.LoadSceneAsync(sceneName);
        while (!OP.isDone)
        {
            yield return null;
            Debug.Log(OP.progress);
        }
        OP.allowSceneActivation = true;
    }
}
