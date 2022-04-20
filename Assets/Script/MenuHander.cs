using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHander : MonoBehaviour
{
    [SerializeField] private GameObject HomePanal;
    [SerializeField] private GameObject DifficultySetPanal;

    public void OpenSelectDifficulty()
    {
        DifficultySetPanal.SetActive(true);
        Openpanel_D();
        HomePanal.SetActive(false);
    }

    public void StartGame_Normal()
    {
        PlayerPrefs.SetInt("Gamemode", 0);
        SceneManager.LoadScene(1);

    }
    public void StartGame_Chill()
    {
        PlayerPrefs.SetInt("Gamemode", 1);
        SceneManager.LoadScene(1);
    }
    public void Openpanel_D()
    {
        Animator animetor = DifficultySetPanal.GetComponent<Animator>();
        animetor.SetBool("Opened", true);
    }

    public void Closepanal_D()
    {
        Animator animetor = DifficultySetPanal.GetComponent<Animator>();
        animetor.SetBool("Opened", false);
        HomePanal.SetActive(true);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
