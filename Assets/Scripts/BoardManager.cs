using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

    
public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count {
        public int Minimum;
        public int Maximum;

        public Count(int min,int max)
        {
            Minimum = min;
            Maximum = max;
        }
    }

    public int Columns = 8;
    public int Rows = 8;
    public Count WallCount = new Count(5, 9);
    public Count FoodCount = new Count(1, 5);
    public GameObject exit;
    public GameObject[] Floortiles;
    public GameObject[] WallTiles;
    public GameObject[] FoodTiles;
    public GameObject[] EnemyTiles;
    public GameObject[] OuterWallTiles;

    private Transform BoardHolder;
    private List<Vector3> gridposition = new List<Vector3>();

    private void InitializeList()
    {
        gridposition.Clear();

        for (int x = 1; x < Columns-1; x++)
        {
            for (int y = 1; y < Rows - 1; y++)
            {
                gridposition.Add(new Vector3(x, y, 0f));
            }
        }
    }

    private void BoardSetup()
    {
        BoardHolder = new GameObject("Board").transform;
        for(int x = -1; x < Columns + 1; x++)
        {
            for (int y = -1; y < Rows + 1; y++)
            {
                GameObject ToInstantiate = Floortiles[Random.Range(0,Floortiles.Length)];
                if (x==-1||x==Columns||y==-1||y==Rows)
                {
                    ToInstantiate = OuterWallTiles[Random.Range(0, OuterWallTiles.Length)];
                }
                GameObject Instance = Instantiate(ToInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                Instance.transform.SetParent(BoardHolder);  
            }
        }   
    }

    Vector3 RandomPosition()
    {
        int RandomIndex = Random.Range(0, gridposition.Count);
        Vector3 RandomPos = gridposition[RandomIndex];
        gridposition.RemoveAt(RandomIndex);
        return RandomPos;
    }

    void LayoutObjectAtRandom(GameObject[] TileArray,int Minimum, int Maximum)
    {
        int objectCount = Random.Range(Minimum, Maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject TileChoice = TileArray[Random.Range(0, TileArray.Length)];
            Instantiate(TileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene(int level)
    {
        BoardSetup();
        InitializeList();
        LayoutObjectAtRandom(WallTiles, WallCount.Minimum, WallCount.Maximum);
        LayoutObjectAtRandom(FoodTiles, FoodCount.Minimum, FoodCount.Maximum);
        int EnemyCount = (int)Mathf.Log(level, 2f);
        LayoutObjectAtRandom(EnemyTiles, EnemyCount, EnemyCount);
        Instantiate(exit, new Vector3(Columns - 1, Rows - 1, 0f), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
