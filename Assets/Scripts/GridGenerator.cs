using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject gridSquare;
    public GameObject StartGridSquare;
    public GameObject FinishGridSquare;
    public GameObject wall;
    public Material visitedMat;
    public int maxXValue;
    public int maxZValue;
    int i = 0;
    int j = 0;
    bool[,,] whatWallsExist;
    bool visited = false;
    GameObject[,] gridSquares;
    GameObject currentSquare;
    GameObject wallTop;
    GameObject wallRight;
    GameObject wallBottom;
    GameObject wallLeft;
    //This gives designers something to help them understand what you have created
    [Tooltip("Where the starting point is")]
    public Vector2 startingPoint = new Vector2(0,0);
    [Tooltip("Where the ending point is")]
    public Vector2 endingPoint = new Vector2(0, 0);

    void Start()
    {
        whatWallsExist = new bool [maxXValue, maxZValue, 4];
        gridSquares = new GameObject[maxXValue, maxZValue];
        Grid();
        BackTracking();
    }

    void Update()
    {
        //TODO I think the bool for the walls needs to be here?? 
    }

    void Grid()
    {
       // bool[] whatWallsExist = new bool[4] { true, true, true, true };
        //takes the value given x and loops until it reaches the end
        for (i = 0; i < maxZValue; i++)
        {
            //takes the value given y and loops until it reaches the end, creating a grid
            for (j = 0; j < maxXValue; j++)
            {
                //checks if it has reached the desiered start position of the maze
                if (j == startingPoint.x && i == startingPoint.y)
                {
                    //adds the current x,y of the grid tile to an array
                    gridSquares[j, i] = Instantiate(StartGridSquare, new Vector3(j * 1, 0, i * 1), Quaternion.identity);
                    if (whatWallsExist[j, i, 0])
                    {
                        wallTop = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z + .5f), Quaternion.Euler(0, 90, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[j, i, 1])
                    {
                        wallRight = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x + .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[j, i, 2])
                    {
                        wallBottom = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z - .5f), Quaternion.Euler(0, 90, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[j, i, 3])
                    {
                        wallLeft = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x - .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0), gridSquares[j, i].transform);
                    }

                }
                //checks if it has reached the desiered end position of the maze - This will change
                else if (j == endingPoint.x && i == endingPoint.y)
                {
                    gridSquares[j, i] = Instantiate(FinishGridSquare, new Vector3(j * 1, 0, i * 1), Quaternion.identity);
                    if (whatWallsExist[j, i, 0])
                    {
                        wallTop = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z + .5f), Quaternion.Euler(0, 90, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[j, i, 1])
                    {
                        wallRight = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x + .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[j, i, 2])
                    {
                        wallBottom = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z - .5f), Quaternion.Euler(0, 90, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[j, i, 3])
                    {
                        wallLeft = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x - .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0), gridSquares[j, i].transform);
                    }
                }
                else
                {

                    gridSquares[j, i] = Instantiate(gridSquare, new Vector3(j * 1, 0, i * 1), Quaternion.identity);
                    //TODO bool visited = false;
                    if (whatWallsExist[j, i, 0])
                    {
                        wallTop = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z + .5f), Quaternion.Euler(0, 90, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[j, i, 1])
                    {
                        wallRight = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x + .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[j, i, 2])
                    {
                        wallBottom = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z - .5f), Quaternion.Euler(0, 90, 0), gridSquares[j, i].transform);
                    }
                    if (whatWallsExist[j, i, 3])
                    {
                        wallLeft = Instantiate(wall, new Vector3(gridSquares[j, i].transform.position.x - .5f, gridSquares[j, i].transform.position.y + .5f, gridSquares[j, i].transform.position.z), Quaternion.Euler(0, 0, 0), gridSquares[j, i].transform);
                    }
                }
            }
        }
    }
    void BackTracking()
    {
        currentSquare = gridSquares[0, 0];
            currentSquare.GetComponent<Renderer>().material = visitedMat;
    }
}
