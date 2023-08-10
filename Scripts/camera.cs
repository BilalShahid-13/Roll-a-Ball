using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] Transform Camera_;
    [SerializeField] Transform[] player;
    [SerializeField] Vector3 offset;
    string b;

    private void Start()
    {
        b = PlayerPrefs.GetString("Character");
    }
    void FixedUpdate()
    {
        Camera_.position = player[0].position + offset;Camera_.position = player[0].position + offset;
        if (b == "Box")
        {
            Camera_.position = player[0].position + offset;
        }
        else if(b == "Circle")
        {
            Camera_.position = player[1].position + offset;
        }

    }

    
}
