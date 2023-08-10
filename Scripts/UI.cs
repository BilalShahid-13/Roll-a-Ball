using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject optionmeunu,buttons,lvls;
    [SerializeField] AudioSource idle;
    string b;
    respawn r = new respawn();

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


        if (PlayerPrefs.GetInt("mainmenu") == 2)
        {
               optionmeunu.SetActive(true);  
                buttons.SetActive(false);
            lvls.SetActive(false);
            PlayerPrefs.DeleteKey("mainmenu");
        }
    }
    public void Start_(int lvl)
    {
        SceneManager.LoadScene("Game");
        PlayerPrefs.SetInt("lvl count", lvl);
    }


    public void exit()
    {
        Application.Quit();
    }

    public void box()
    {
        PlayerPrefs.SetString("Character","Box");
        b = PlayerPrefs.GetString("Character");
        Debug.Log("box");
        Debug.Log(b);
    }

    public void circle()
    {
        PlayerPrefs.SetString("Character", "Circle");
        b = PlayerPrefs.GetString("Character");
        Debug.Log(b);
    }

    public void restart()
    {
        r.lvl();
    }

    public void sound_on()
    {
        idle.Play();
        PlayerPrefs.SetInt("sound", 3);
    }
    public void sound_off()
    {
        idle.Pause();
        PlayerPrefs.SetInt("sound", 2);
    }

}
