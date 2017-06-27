using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    public Transform gridSquare;
    public int maxXValue;
    public int maxYValue;
    private int currentYValue = 1;


    // Use this for initialization
    void Start () {
        {
            for (int i = 0; i < maxXValue;)
            {
                Instantiate(gridSquare, new Vector3(currentYValue * 1.1f, 0, i * 1.1f), Quaternion.identity);
                i++;
                if ((i == (maxXValue)) & (currentYValue != maxYValue))
                {
                    i = 0;
                    currentYValue++;
                }
            }
     
        }
    
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
