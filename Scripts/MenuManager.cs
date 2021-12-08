using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel_2;
    public GameObject panel_3;

    public void openOptionsMenu()
    {
        panel.gameObject.SetActive(true);
    }

    public void openVolume()
    {
        panel_2.gameObject.SetActive(true);
    }

    public void closeVolume()
    {
        panel_2.gameObject.SetActive(false);
    }

    public void openHowToPlay()
    {
        panel_3.gameObject.SetActive(true);
    }

    public void closeHowToPlay()
    {
        panel_3.gameObject.SetActive(false);
    }

    public void closeOptionsMenu()
    {
        panel.gameObject.SetActive(false);
    }
    public void ChangeSceneToGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Screen.SetResolution(1280, 720, false);
    }
}