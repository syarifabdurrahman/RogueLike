using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public BoardManager BoardScript;

    private int Level = 3;

    // Start is called before the first frame update
    void Awake()
    {
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
