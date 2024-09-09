using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapCharacter : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        // When map is loaded,we ask Game manager,if it has some info about currentLevel
        //if it has ,then we know we are coming back from some level
        //so we can fetch the object and the spawnpoint of it.we move mapchracter to that location
        if (GameManager.manager.currentLevel != "")
        {

            transform.position = GameObject.Find(GameManager.manager.currentLevel).transform.GetChild(1).transform.position;
            GameObject.Find(GameManager.manager.currentLevel).GetComponent<LoadLevel>().Cleared(true);


        }


    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalMove = Input.GetAxis("Vertical") *speed * Time.deltaTime;
        transform.Translate(horizontalMove,verticalMove,0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LevelTrigger"))
        {
            GameManager.manager.currentLevel = collision.gameObject.name;

            SceneManager.LoadScene(collision.GetComponent<LoadLevel>().levelToLoad);
        }
    }
}
