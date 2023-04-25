using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void LoadScene(string menu)
    {
        SceneManager.LoadScene(menu); 
    }
    public void LoadEasyGame(string menu)
    {
        GameSettings.ins.SetGameMode(GameSettings.EGameMode.EASY);
        SceneManager.LoadScene(menu);
    }
    public void LoadMediumGame(string menu)
    {
        GameSettings.ins.SetGameMode(GameSettings.EGameMode.MEDIUM);
        SceneManager.LoadScene(menu);
    }
    public void LoadHardGame(string menu)
    {
        GameSettings.ins.SetGameMode(GameSettings.EGameMode.HARD);
        SceneManager.LoadScene(menu);
    }
    public void LoadVeryHardGame(string menu)
    {
        GameSettings.ins.SetGameMode(GameSettings.EGameMode.VERY_HARD);
        SceneManager.LoadScene(menu);
    }

    public void ActivateObject(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void DeactivateObject(GameObject obj)
    {
        obj.SetActive(false);
    }

}
