using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("¹CÀ¸³õ´º");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
