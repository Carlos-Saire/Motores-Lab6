using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Close()
    {
        Application.Quit();
    }
    public void TimeGame(int time)
    {
        Time.timeScale = time;
    }
}
