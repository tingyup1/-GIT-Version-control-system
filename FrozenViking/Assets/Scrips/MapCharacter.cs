using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapCharacter : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        // when map ia loaded, we adkk Game Manager, if it has some info zbout currentLevel
        // If it has , then we know.....
        if (GameManager.manager.currentLevel != "") 
        {
            // we move the player...
            transform.position = GameObject.Find(GameManager.manager.currentLevel).transform.GetChild(1).transform.position;
            GameObject.Find(GameManager.manager.currentLevel).GetComponent<LoadLevel>().Cleared(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(horizontalMove, verticalMove, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LevelTrigger"))
        {
            // we tell Game Manager,that we are entering a level, GM
            GameManager.manager.currentLevel = collision.gameObject.name;
            
            
            SceneManager.LoadScene(collision.GetComponent<LoadLevel>().levelToLoad);

        }
    }
}
