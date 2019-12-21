using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void ReturnGame()
    {
        Manager.Instance.IsPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
