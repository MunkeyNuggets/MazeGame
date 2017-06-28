using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    public GameObject gridSquare;
    public GameObject StartGridSquare;
    public GameObject FinishGridSquare;
    public int maxXValue;
    public int maxZValue;
    private int currentXValue = 1;
    GameObject[,] gridSquares;
    public int StartX = 0;
    public int StartY = 0;
    public int EndX = 9;
    public int EndY = 9;

    // Use this for initialization
    void Start()
    {

        gridSquares = new GameObject[maxXValue, maxZValue];


        for (int i = 0; i < maxZValue; i++)
        {
            for (int j = 0; j < maxXValue; j++)
            {
                if (j == StartX && i == StartY)
                {
                    gridSquares[j, i] = Instantiate(StartGridSquare, new Vector3(j * 1.1f, 0, i * 1.1f), Quaternion.identity);
                }
                else if (j == EndX && i == EndY)
                {
                    gridSquares[j, i] = Instantiate(FinishGridSquare, new Vector3(j * 1.1f, 0, i * 1.1f), Quaternion.identity);
                }
                else
                {
                    gridSquares[j, i] = Instantiate(gridSquare, new Vector3(j * 1.1f, 0, i * 1.1f), Quaternion.identity);
                }
            }
            /*      
             *      if (i == 0 & currentXValue == 1)
                  {
                      Instantiate(StartGridSquare, new Vector3(currentXValue * 1.1f, 0, i * 1.1f), Quaternion.identity);
                      i++;
                  }

                  if ((i == (maxZValue - 1)) & currentXValue == maxXValue)
                  {
                      Instantiate(FinishGridSquare, new Vector3(currentXValue * 1.1f, 0, i * 1.1f), Quaternion.identity);
                      i++;
                  }
                  if ((i == (maxZValue)) & (currentXValue != maxXValue))
                  {
                      i = 0;
                      currentXValue++;
                  }
              */
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
