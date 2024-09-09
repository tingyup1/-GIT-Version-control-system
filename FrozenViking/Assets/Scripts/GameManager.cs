using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public string currentLevel;

    public float health;  //current health left
    public float previousHealth; //This is the health we had before we took some damage 90
    public float maxHealth; // This is tell what is the maximum value of health

    public bool Level1;
    public bool Level2;
    public bool Level3;

    private void Awake()
    {
        //singleton
        //we want to make sure we have only one instance of GameManager in our game
        if (manager == null)
        {
            //if we dont have manager,let's tell that this class instance is the manager
            //we also tell that this manager cannot be destroyed if we changer the scene
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else
        {
            //we'll run this if there is already a manager in the scene for some reason
            //the manager will be a 
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData data = new PlayerData();
        //copy infor from game manager to playerdata
        data.health=health;
        data.previousHealth=previousHealth;
        data.maxHealth=maxHealth;
        data.Level1 = Level1;
        data.Level2 = Level2;
        data.Level3 = Level3;
        bf.Serialize(file,data);
        file.Close();
}

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfor.dat")){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +"/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            health=data.health; 
            previousHealth=data.previousHealth;
            maxHealth=data.maxHealth;
            Level1 = data.Level1;
            Level2 = data.Level2;
            Level3 = data.Level3;
}
    }
}


//Another class that we can serialize,this contains only the information we are going to store.
[Serializable]
class PlayerData
{
    public string currentLevel;

    public float health; 
    public float previousHealth; 
    public float maxHealth;

    public bool Level1;
    public bool Level2;
    public bool Level3;
}
