using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    [SerializeField] TMP_Text[] highscore;
    [SerializeField] GameObject gameover_, nextlvl;
    [SerializeField] AudioSource idle;
    int a,b;
    UI ui = new UI();

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            idle.Play();
        }
        else if (PlayerPrefs.GetInt("sound") == 3)
        {
            idle.Play();
        }
        else if (PlayerPrefs.GetInt("sound") == 2)
        {
            idle.Pause();
        }

        highscore[0].text = PlayerPrefs.GetString("score");
        highscore[1].text = PlayerPrefs.GetString("score");

        b = PlayerPrefs.GetInt("gameover_t/f");
        if(b == 2)
        {
            nextlvl.SetActive(true);    
            gameover_.SetActive(false);    

        }
        else if(b == 3)
        {
            gameover_.SetActive(true);
            nextlvl.SetActive(false);
        }
    }
    public void restart()
    {
       a =  PlayerPrefs.GetInt("lvl count");
        SceneManager.LoadScene("Game");
    }
    public void menu()
    {
        SceneManager.LoadScene("UI");
        PlayerPrefs.SetInt("mainmenu", 2);
    }
    public void next_lvl()
    {
        SceneManager.LoadScene("Game");
    }

    public void exit()
    {
        ui.exit();
    }
}
