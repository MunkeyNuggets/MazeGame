using System.Collections;
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
    GameObject[,] gridSquares;
    //bool[] whatWallsExist;
    //any square that hasn't been visited will have a bool of false
    bool visited = false;
    //currentSquare is the current square selected by recursive backtracking 
    GameObject currentSquare;
    


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
        currentSquare = gridSquares[0,0];
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
                        wallTop = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z + .5f), Quaternion.Euler(0, 90, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[1] == true)
                    {
                        wallRight = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x + .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[2] == true)
                    {
                        wallBottom = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z - .5f), Quaternion.Euler(0, 90, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[3])
                    {
                        wallLeft = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x - .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0), gridSquares[j, i].transform);
                    }

                }
                //checks if it has reached the desiered end position of the maze - This will change
                else if (j == endingPoint.x && i == endingPoint.y)
                {
                    gridSquares[j, i] = Instantiate(FinishGridSquare, new Vector3(j * 1, 0, i * 1), Quaternion.identity);
                    if (whatWallsExist[0] == true)
                    {
                        wallTop = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z + .5f), Quaternion.Euler(0, 90, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[1] == true)
                    {
                        wallRight = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x + .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[2] == true)
                    {
                        wallBottom = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z - .5f), Quaternion.Euler(0, 90, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[3])
                    {
                        wallLeft = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x - .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0), gridSquares[j, i].transform);
                    }
                }
                else
                {
                   
                    gridSquares[j, i] = Instantiate(gridSquare, new Vector3(j * 1, 0, i * 1), Quaternion.identity);
                    if (whatWallsExist[0] == true)
                    {
                        wallTop = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z + .5f), Quaternion.Euler(0, 90, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[1] == true)
                    {
                        wallRight = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x + .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[2] == true)
                    {
                        wallBottom = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z - .5f), Quaternion.Euler(0, 90, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[3])
                    {
                        wallLeft = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x - .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0), gridSquares[j, i].transform);
                    }
                }
            }
            /*    if (i == 0 & maxXValue == 1)
                  {
                      Instantiate(StartGridSquare, new Vector3(maxXValue * 1.1f, 0, i * 1.1f), Quaternion.identity);
                      i++;
                  }

                  if ((i == (maxZValue - 1)) & maxXValue == maxXValue)
                  {
                      Instantiate(FinishGridSquare, new Vector3(maxXValue * 1.1f, 0, i * 1.1f), Quaternion.identity);
                      i++;
                  }
                  if ((i == (maxZValue)) & (maxXValue != maxXValue))
                  {
                      i = 0;
                      maxXValue++;
                  }
              */
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
