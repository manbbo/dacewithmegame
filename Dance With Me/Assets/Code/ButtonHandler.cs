using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject[] obj;
    
    public void btExit()
    {
        Application.Quit();
    }

    public void GoToScreen(string SceneName)
    {
        SceneManager.LoadSceneAsync(SceneName);
    }

    public void PauseGame(bool state)
    {
        FixedThings.paused = state;
        obj[0].SetActive(!state);
        obj[1].SetActive(state);
    }

    public void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void CloseDialog()
    {
        FixedThings.prompting = false;
        obj[2].SetActive(false);
    }
}
