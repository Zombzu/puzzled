using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LevelSelect()
    {
        SceneManager.LoadScene(1);
        Display.displays[1].Activate();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene(2);
        Display.displays[2].Activate();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Display.displays[1].Activate();
    }
}
