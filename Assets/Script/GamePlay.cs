using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public GameObject effect;
    public int HP = 3;
    public int goal = 0;
    public static GamePlay instance;
    public int GameMode = 0; //0 = normal, 1 = Chill
    public GameObject[] HpBar;
    [SerializeField] public GameObject[] Panal;
    public GameObject MC_A;
    public GameObject MC_B;
    [SerializeField]public GameObject Minimap;
    public bool IsMini = false;
    public GameObject spawnpointA;
    public GameObject spawnpointB;
    void Start()
    {
        instance = this;
        GameMode = PlayerPrefs.GetInt("Gamemode");
        CheckGamemode();
        MC_A = GameObject.FindGameObjectWithTag("MC1");
        MC_B = GameObject.FindGameObjectWithTag("MC2");
        spawnpointA = GameObject.FindGameObjectWithTag("spawnpointA");
        spawnpointB = GameObject.FindGameObjectWithTag("spawnpointB");
        Debug.Log(GameMode);
    }

    void Update()
    {
        minimap();
    }

    private void gameover()
    {
        Time.timeScale = 0;
        Audiomaneger.instance.audioLose();
        Panal[0].SetActive(true);
    }

    public void LoseHP()
    {
        Audiomaneger.instance.audiolostHP();
        Respawn(MC_A, spawnpointA);
        Respawn(MC_B, spawnpointB);
        if (GameMode == 0)
        {
            Instantiate(effect, new Vector3(HpBar[HP - 1].gameObject.transform.position.x, HpBar[HP - 1].gameObject.transform.position.y, HpBar[HP - 1].gameObject.transform.position.z), Quaternion.identity);
            Destroy(HpBar[HP - 1]);
            HP -= 1;
            if(HP == 0)
            {
                gameover();
            }
        }
    }

    public void Respawn(GameObject player, GameObject spawnpoint)
    {
        player.transform.position = spawnpoint.transform.position;
    }

    private void CheckGamemode()
    {
        if (GameMode == 1)
        {
            foreach(GameObject i in HpBar)
            {
                i.SetActive(false);
            }
        }
    }

    private void minimap()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsMini == false)
            {
                Time.timeScale = 0;
                Minimap.SetActive(true);
                IsMini = !IsMini;
            }
            else if (IsMini == true)
            {
                Time.timeScale = 1;
                Minimap.SetActive(false);
                IsMini = !IsMini;
            }
        }
    }

    public void Goal()
    {
        goal += 1;
        Audiomaneger.instance.audioDuality();
        if (goal == 2)
        {
            Win();
        }
    }

    private void Win()
    {
        Time.timeScale = 0;
        Audiomaneger.instance.audioWin();
        Panal[1].SetActive(true);
    }
}
