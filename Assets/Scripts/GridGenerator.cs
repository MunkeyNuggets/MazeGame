﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    public GameObject gridSquare;
    public GameObject StartGridSquare;
    //TODO change this so that there a collectables rather than 1 set end zone
    public GameObject FinishGridSquare;
    //bool[] walls;
    public GameObject wall;
    //
    public int maxXValue;
    public int maxZValue;
    private int currentXValue = 1;
    GameObject[,] gridSquares;
    bool[] whatWallsExist;

    GameObject wallTop;
    GameObject wallRight;
    GameObject wallBottom;
    GameObject wallLeft;


    /*public int StartX = 0;
    public int StartY = 0;
    public int EndX = 9;
    public int EndY = 9;*/

    //This gives designers something to help them understand what you have created
    [Tooltip("Where the starting point is")]
    public Vector2 startingPoint = new Vector2(0,0);

    [Tooltip("Where the ending point is")]
    public Vector2 endingPoint = new Vector2(0, 0);

    // Use this for initialization
    void Start()
    {
        bool[] whatWallsExist = new bool[4] {true, true, true, true};
        gridSquares = new GameObject[maxXValue, maxZValue];

        //takes the value given x and loops until it reaches the end
        for (int i = 0; i < maxZValue; i++)
        {
            //takes the value given y and loops until it reaches the end, creating a grid
            for (int j = 0; j < maxXValue; j++)
            {
                //checks if it has reached the desiered start position of the maze
                if (j == startingPoint.x && i == startingPoint.y)
                {
                    //adds the current x,y of the grid tile to an array
                    gridSquares[j, i] = Instantiate(StartGridSquare, new Vector3(j * 1, 0, i * 1), Quaternion.identity);
                    if (whatWallsExist[0] == true)
                    {
                        wallTop = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z + .5f), Quaternion.Euler(0, 90, 0));
                    }
                    if (whatWallsExist[1] == true)
                    {
                        wallRight = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x + .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0));
                    }
                    if (whatWallsExist[2] == true)
                    {
                        wallBottom = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z - .5f), Quaternion.Euler(0, 90, 0));
                    }
                    if (whatWallsExist[3])
                    {
                        wallLeft = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x - .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0));
                    }

                    
                   
                   
                    //Trying to set the parent of all he walls to the current grid square...

                    //wallTop.transform.parent = StartGridSquare.transform;
                    //wallRight.transform.parent = StartGridSquare.transform;
                    //wallBottom.transform.parent = StartGridSquare.transform;
                    //wallLeft.transform.parent = StartGridSquare.transform;
                }
                //checks if it has reached the desiered end position of the maze - This will change
                else if (j == endingPoint.x && i == endingPoint.y)
                {
                    gridSquares[j, i] = Instantiate(FinishGridSquare, new Vector3(j * 1, 0, i * 1), Quaternion.identity);
                    if (whatWallsExist[0] == true)
                    {
                        wallTop = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z + .5f), Quaternion.Euler(0, 90, 0));
                    }
                    if (whatWallsExist[1] == true)
                    {
                        wallRight = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x + .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0));
                    }
                    if (whatWallsExist[2] == true)
                    {
                        wallBottom = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z - .5f), Quaternion.Euler(0, 90, 0));
                    }
                    if (whatWallsExist[3])
                    {
                        wallLeft = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x - .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0));
                    }

                    //wallTop.transform.parent = FinishGridSquare.transform;
                    //wallRight.transform.parent = FinishGridSquare.transform;
                    //wallBottom.transform.parent = FinishGridSquare.transform;
                    //wallLeft.transform.parent = FinishGridSquare.transform;
                }
                else
                {
                   
                    gridSquares[j, i] = Instantiate(gridSquare, new Vector3(j * 1, 0, i * 1), Quaternion.identity);
                    if (whatWallsExist[0] == true)
                    {
                        wallTop = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z + .5f), Quaternion.Euler(0, 90, 0));
                    }
                    if (whatWallsExist[1] == true)
                    {
                        wallRight = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x + .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0));
                    }
                    if (whatWallsExist[2] == true)
                    {
                        wallBottom = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z - .5f), Quaternion.Euler(0, 90, 0));
                    }
                    if (whatWallsExist[3])
                    {
                        wallLeft = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x - .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0));
                    }

                    //wallTop.transform.parent = gridSquare.transform;
                    //wallRight.transform.parent = gridSquare.transform;
                    //wallBottom.transform.parent = gridSquare.transform;
                    //wallLeft.transform.parent = gridSquare.transform;
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
