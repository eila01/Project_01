using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public int _menuScene;
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void ReturnMainMenu()
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene(_menuScene);
    }

}
