using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public string levelToLoad; // Name of the scene we want to open

    public bool cleared;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.manager.GetType().GetField(levelToLoad).GetValue(GameManager.manager).ToString() == "True")
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
        if(IsClear == true)
        {
            cleared = true;

            GameManager.manager.GetType().GetField(levelToLoad).SetValue(GameManager.manager, true);


            // Display Level Clear sign
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;

            GetComponent<CircleCollider2D>().enabled = true;


        }




    }
}
