using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class color : MonoBehaviour
{
    Renderer r;
    [SerializeField] GameObject[] g;
    [SerializeField] Material[] m;
    [SerializeField] TMP_Text txt;
    [SerializeField] Animator cube_anim, sphere_anim;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        //r.material = Color.cyan;
        //g.GetComponent<Renderer>().material = Color.magenta;
        //g.GetComponent<Renderer>().material = m;
    }
    public void box_color(string s)
    {
         txt.text = s;
        PlayerPrefs.SetString("Colors",s);
        if(s == "Red" ||  s == "Green" || s == "Yellow")
        {
            g[0].SetActive(true);
            g[1].SetActive(false);
            g[0].GetComponent<Animator>().enabled = true;
            g[1].GetComponent<Animator>().enabled = false;
            if (s == "Red")
            {
                g[0].GetComponent<Renderer>().material = m[0];
            }
            else if (s == "Green")
            {
                g[0].GetComponent<Renderer>().material = m[1];
            }
            else if (s == "Yellow")
            {
                g[0].GetComponent<Renderer>().material = m[2];
            }
        }
        else
        {
            g[1].SetActive(true);
            g[0].SetActive(false);
            g[0].GetComponent<Animator>().enabled = false;
            g[1].GetComponent<Animator>().enabled = true;
            if (s == "Blue")
            {
                g[1].GetComponent<Renderer>().material = m[3];
            }
            else if (s == "Pink")
            {
                g[1].GetComponent<Renderer>().material = m[4];
            }
            else if (s == "Purple")
            {
                g[1].GetComponent<Renderer>().material = m[5];
            }
        }
        

        
    }
}
