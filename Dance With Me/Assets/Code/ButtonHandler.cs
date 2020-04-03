using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject[] obj;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
