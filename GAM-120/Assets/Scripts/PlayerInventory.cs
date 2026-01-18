using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //Array to store collection statuses of tools
    /*
     * Tool 0:
     * Tool 1:
     * Tool 2:
     */
    [Tooltip("Remember to have this value match the number of tools in the game")]
    public List<bool> tools = new List<bool> { false, false, false };

    //Array to store collection statuses of exhaustibles
    /*
     * Exhaustible 0:
     * Exhaustible 1:
     * Exhaustible 2:
     */
    [Tooltip("Remember to have this value match the how many types of exhaustibles are in the game")]
    public List<int> exhaustibles = new List<int> { 0,0,0};



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectTool(int toolIndex) 
    {
        tools[toolIndex] = true;
        Debug.Log("Tool no. " + toolIndex +" collected!");
    }

    public void CollectExhaustible(int exhaustibleIndex, int amountToAdd)
    {
        exhaustibles[exhaustibleIndex] += amountToAdd;
        Debug.Log("Exhaustible no. " + exhaustibleIndex + " collected, added " + amountToAdd +" !");
    }
}
