using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerCellsPerSecond : MonoBehaviour
{
    public Text pointsText;
    private float pointsAmount;
    public float pointsIncreasedPerSecond;
    private GameObject[] getCount;



    // Start is called before the first frame update
    void Start()
    {
        pointsText = GameObject.FindGameObjectWithTag("text").GetComponent<Text>();
        pointsAmount = 15f;
        
    }

    // Update is called once per frame
    void Update()
    {
        getCount = GameObject.FindGameObjectsWithTag("scientist");
        pointsIncreasedPerSecond = getCount.Length;

        pointsText.text = (int)pointsAmount + " Power Cells";
        pointsAmount += pointsIncreasedPerSecond * Time.deltaTime;

        Debug.Log(pointsAmount);

        
    }
}
