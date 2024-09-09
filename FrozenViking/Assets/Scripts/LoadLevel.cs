using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public string levelToLoad; //name of the scene we want to open

    public bool cleared;
    // Start is called before the first frame update
    void Start()
    {
        //When we open mapscene,we check does Gamemanager marked this level as passed.
        //If it is passed,then we run cleared function with parameter true.That will display level cleared image and remove collider.
        if (GameManager.manager.GetType().GetField(levelToLoad).GetValue(GameManager.manager).ToString() == "True")
        {
            Cleared(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cleared(bool IsClear)
    {
        if (IsClear == true)
        {
            cleared = true;
            //we set correct boolean variable true in Game Manager
            GameManager.manager.GetType().GetField(levelToLoad).SetValue(GameManager.manager,true);
            //Display LevelClearIcon
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            //Beacuse level is passed,we want todisable collider,so we back to already passed level.
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
