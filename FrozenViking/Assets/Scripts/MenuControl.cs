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
        GameManager.manager.Save();
    }
    public void Load()
    {
        Debug.Log("Load Pressed");
        GameManager.manager.Load();
    }
}