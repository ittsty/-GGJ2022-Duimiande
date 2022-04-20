using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject panelResume;
    private bool isPause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            if (isPause == false)
            {
                showMenu();
                isPause = !isPause;
            }
            else if (isPause == true)
            {
                hideMenu();
                isPause = !isPause;
            }
        }
    }

    public void showMenu()
    {
        panelResume.SetActive(true);
        Time.timeScale = 0;
    }
    public void hideMenu()
    {
        panelResume.SetActive(false);
        Time.timeScale = 1;
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
