using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour
{
    [SerializeField] GameObject[] players,lvls;
    [SerializeField] GameObject[] g;
    [SerializeField] Material[] m;
    [SerializeField] Rigidbody rb,rb1;
    [SerializeField] float force, forward;

    GameObject coins;
    bool pointer_l, pointer_r, pointer_f, pointer_b;
    int a;
    string n;
    float t;
    Vector3 v;
    // Start is called before the first frame update

    private void Start()
    {
        Time.timeScale = 1f;
        lvl();
        n = PlayerPrefs.GetString("Character");   
    }

    private void FixedUpdate()
    {
       // rb.AddForce(0, 0, forward * Time.fixedDeltaTime, ForceMode.Force);

        if (players[0].transform.position.y <= -1f || players[1].transform.position.y <= -1f)
        {
            SceneManager.LoadScene("gameover");
        }

        if (pointer_l == true)
        {
            left();
        }
        else if (pointer_r == true)
        {
            right();
        }
        else if (pointer_f == true)
        {
           front();
        }
        else if (pointer_b == true)
        {
            back();
        }

        if (n == "Box")
        {
            players[0].SetActive(true);
            players[1].SetActive(false);

            box_color();
        }
        else if (n == "Circle")
        {
            players[1].SetActive(true);
            players[0].SetActive(false);

            circle_color();
        }
    }  
        
    public void lvl()
    {
        if(PlayerPrefs.GetInt("next_lvl") == 2)
        {
            a = PlayerPrefs.GetInt("next_lvl");
            a++;
        }
        a = PlayerPrefs.GetInt("lvl count");
        switch (a)
        {
            case 1:
                lvls[0].SetActive(true);
                lvls[1].SetActive(false);
                lvls[2].SetActive(false);
                lvls[3].SetActive(false);
                break;
            case 2:
                lvls[0].SetActive(false);
                lvls[1].SetActive(true);
                lvls[2].SetActive(false);
                lvls[3].SetActive(false);
                break;
            case 3:
                lvls[0].SetActive(false);
                lvls[1].SetActive(false);
                lvls[2].SetActive(true);
                lvls[3].SetActive(false);
                break;
            case 4:
                lvls[0].SetActive(false);
                lvls[1].SetActive(false);
                lvls[2].SetActive(false);
                lvls[3].SetActive(true);
                break;
        }
        
    }

   
    public void left()
    {
        rb.AddForce(-force * Time.fixedDeltaTime, 0, 0, ForceMode.Force);
        rb1.AddForce(-force * Time.fixedDeltaTime, 0, 0, ForceMode.Force);
        
    }
    public void right()
    {
        rb.AddForce(force * Time.fixedDeltaTime, 0, 0, ForceMode.Force);
        rb1.AddForce(force * Time.fixedDeltaTime, 0, 0, ForceMode.Force);
    }
    void front()
    {
        rb.AddForce(0, 0, forward * Time.fixedDeltaTime, ForceMode.Force);
        rb1.AddForce(0, 0, forward * Time.fixedDeltaTime, ForceMode.Force);
    }
    void back()
    {
        rb.AddForce(0, 0, -forward * Time.fixedDeltaTime, ForceMode.Force);
        rb1.AddForce(0, 0, -forward * Time.fixedDeltaTime, ForceMode.Force);
    }

    public void left_sphere()
    {
       v = new Vector3(-2f * force, 0, 0f);
        rb1.AddForce(v * Time.fixedDeltaTime, ForceMode.Force);

    }

    public void right_sphere()
    {
        v = new Vector3(2f * force, 0, 0f);
        rb1.AddForce(v * Time.fixedDeltaTime, ForceMode.Force);
    }

    public void pointer_up_left()
    {
        pointer_l = false;
    }
    public void pointer_down_left()
    {
        pointer_l = true;
    }
    public void pointer_up_right()
    {
        pointer_r = false;
    }
    public void pointer_down_right()
    {
        pointer_r = true;
    }
    public void pointer_up_forward()
    {
        pointer_f = false;
    }
    public void pointer_down_forward()
    {
        pointer_f = true;
    }
    public void pointer_up_backward()
    {
        pointer_b = false;
    }
    public void pointer_down_backward()
    {
        pointer_b = true;
    }


    void box_color()
    {
        if (PlayerPrefs.GetString("Colors") == "Red")
        {
            g[0].GetComponent<Renderer>().material = m[0];
        }
        else if (PlayerPrefs.GetString("Colors") == "Green")
        {
            g[0].GetComponent<Renderer>().material = m[1];
        }
        else if (PlayerPrefs.GetString("Colors") == "Yellow")
        {
            g[0].GetComponent<Renderer>().material = m[2];
        }
    }
    void circle_color()
    {
        if (PlayerPrefs.GetString("Colors") == "Blue")
        {
            g[1].GetComponent<Renderer>().material = m[3];
        }
        else if (PlayerPrefs.GetString("Colors") == "Pink")
        {
            g[1].GetComponent<Renderer>().material = m[4];
        }
        else if (PlayerPrefs.GetString("Colors") == "Purple")
        {
            g[1].GetComponent<Renderer>().material = m[5];
        }
    }

}

