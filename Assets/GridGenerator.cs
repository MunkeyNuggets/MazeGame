using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    public Transform gridSquare;
    public int maxXValue;
    public int maxZValue;
    private int currentZValue = 1;


    // Use this for initialization
    void Start () {
        {
            for (int i = 0; i < maxZValue;)
            {
                Instantiate(gridSquare, new Vector3(currentZValue * 1.1f, 0, i * 1.1f), Quaternion.identity);
                i++;
                if ((i == (maxZValue)) & (currentZValue != maxXValue))
                {
                    i = 0;
                    currentZValue++;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
