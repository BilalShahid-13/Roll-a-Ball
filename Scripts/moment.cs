using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moment : MonoBehaviour
{
    [SerializeField] TMP_Text score,pause_score;
    [SerializeField] AudioSource idle;
    [SerializeField] Animator setting_anim;

    GameObject[] coin;
    int c,i;

    gameover g = new gameover();
    private void Start()
    {
        Time.timeScale = 1f;

        if (PlayerPrefs.GetInt("sound") == 0)
        {
            idle.Play();
        }
        else if(PlayerPrefs.GetInt("sound") == 3)
        {
            idle.Play();
         }
        else if(PlayerPrefs.GetInt("sound") == 2)
        {
            idle.Pause();
        }
        
        c = PlayerPrefs.GetInt("lvl count");
        Debug.Log(c);
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        // score.text = "Score: " + transform.position.z.ToString("0");
        score.text = i.ToString();
        PlayerPrefs.SetString("score", score.text);
        pause_score.text = score.text;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "enemy")
        {
            SceneManager.LoadScene("gameover");
            PlayerPrefs.SetInt("gameover_t/f", 3);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "lvlcomplete")
        {
            c = c + 1;
            PlayerPrefs.SetInt("levels", c);
            PlayerPrefs.SetInt("lvl count", c);
            PlayerPrefs.SetInt("next_lvl", 2);
            SceneManager.LoadScene("gameover");
            PlayerPrefs.SetInt("gameover_t/f", 2);
        }
        else if(other.gameObject.CompareTag("coins"))
        {
            other.gameObject.SetActive(false);
            i++;
        }
    }
       public void Setting()
    {
        setting_anim.Play("pause_menu");
        Invoke("anim",.65f);
        

    }
    public void play()
    {
        Time.timeScale = 1f;
    }
    public void menu()
    {
        g.menu();
    }

    public void sound_off()
    {
        PlayerPrefs.SetInt("sound", 2);
    }
    public void sound_on()
    {
        PlayerPrefs.SetInt("sound", 3);
    }

    private void anim()
    {
        Time.timeScale = 0f;
        
    }
    
}
