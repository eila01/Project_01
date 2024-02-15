using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGameMenu : MonoBehaviour
{
    public int _gamplayScene;

    public void StartGame()
    {
        SceneManager.LoadScene(_gamplayScene);
    }
}
