using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvlselector : MonoBehaviour
{
    [SerializeField] Button[] buttons = null;
    int lvlreached;
    private void Start()
    {
        lvlreached = PlayerPrefs.GetInt("levels");

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i  > lvlreached)
            {
                buttons[i].interactable = false;
            }

        }
    }
}
