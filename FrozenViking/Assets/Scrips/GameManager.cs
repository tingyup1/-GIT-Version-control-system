using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using JetBrains.Annotations;
using UnityEditor.Experimental.RestService;


public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public string currentLevel;

    public float health; // current health left 70
    public float previousHealth; // this is the health we had before we took some damage 90
    public float maxHealth; // this tell what is the maximun value of health

    public bool Level1;
    public bool Level2;
    public bool Level3;

    // Start is called before the first frame update
    private void Awake()
    {
        // Singleton
        // we want to make sure......
        if(manager == null)
        {

            // if we do not have manager, let's tell that this class instnace is the manager
            // ew also tell that this manager cannot be destroyed if we change the scene.
            DontDestroyOnLoad(gameObject);
            manager = this;


        }
        else
        {


            Destroy(gameObject);
        }


       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {

            SceneManager.LoadScene("MainMenu");
        }
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData data = new PlayerData();

        data.health = health;
        data.previousHealth = previousHealth;
        data.maxHealth = maxHealth;
        data.Level1 = Level1;
        data.Level2 = Level2;
        data.Level3 = Level3;
        bf.Serialize(file, data);
        file.Close();


    }
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);

            file.Close();

            health = data.health;
            previousHealth = data.previousHealth;
            maxHealth = data.maxHealth;
            Level1 = data.Level1;
            Level2 = data.Level2;
            Level3 = data.Level3;


        }


    }


  
       
}
[Serializable]
class PlayerData
{
    public string currentLevel;

    public float health; // current health left 70
    public float previousHealth; // this is the health we had before we took some damage 90
    public float maxHealth; // this tell what is the maximun value of health

    public bool Level1;
    public bool Level2;
    public bool Level3;


}