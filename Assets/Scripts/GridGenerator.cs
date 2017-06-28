using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    public Transform gridSquare;
    public Transform StartGridSquare;
    public Transform FinishGridSquare;
    public int maxXValue;
    public int maxZValue;
    private int currentXValue = 1;


    // Use this for initialization
    void Start () {
        {
            for (int i = 0; i < maxZValue;)
            {
                if (i == 0 & currentXValue == 1)
                {
                    Instantiate(StartGridSquare, new Vector3(currentXValue * 1.1f, 0, i * 1.1f), Quaternion.identity);
                    i++;
                }

                Instantiate(gridSquare, new Vector3(currentXValue * 1.1f, 0, i * 1.1f), Quaternion.identity);
                i++;

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
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
