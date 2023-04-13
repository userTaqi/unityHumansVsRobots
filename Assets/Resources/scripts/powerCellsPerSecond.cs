using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerCellsPerSecond : MonoBehaviour
{
    [SerializeField] GameOver script;
    // Public variable for the UI text that displays the points amount
    public Text pointsText;

    // Private variable for the current points amount
    public float pointsAmount;

    // Public variable for the amount of points increased per second
    public float pointsIncreasedPerSecond;

    // Private array of game objects with the "scientist" tag
    private GameObject[] getCount;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the UI text object with the "text" tag
        pointsText = GameObject.FindGameObjectWithTag("text").GetComponent<Text>();

        // Set the initial points amount to 15
        pointsAmount = 20f;
    }

    // Update is called once per frame
    void Update()
    {   
        if (script.gameAlive){
            // Find all game objects with the "scientist" tag
            getCount = GameObject.FindGameObjectsWithTag("scientist");

            // Set the points increased per second to the number of scientist game objects found
            pointsIncreasedPerSecond = getCount.Length * 0.8f;

            // Update the UI text to show the current points amount as an integer followed by "Power Cells"
            pointsText.text = (int)pointsAmount + " Power Cells";

            // Increase the points amount by the points increased per second multiplied by the time since the last frame
            pointsAmount += pointsIncreasedPerSecond * Time.deltaTime;
        }
        
    }

    /*
    // TODO: This method is not currently used in the code
    void ObjectPrice(){
        pointsAmount -= GameObject.price;
    }
    */
}
