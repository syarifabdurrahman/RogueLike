using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance=null;
    public BoardManager BoardScript;

    private int Level = 3;

    void Awake()
    {
        if (instance=null)
        {
            instance = this;
        }
        else if (instance!=this)
        {
            Destroy(gameObject);
        }
        BoardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        BoardScript.SetupScene(Level);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
