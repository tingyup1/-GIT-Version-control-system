using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void LoadMap()
    {

        SceneManager.LoadScene("Map");


    }
     public void Save()
    {
        Debug.Log("Save Pressed");

    }
    public void Load()
    {

        Debug.Log("Load Pressed");

    }
}
