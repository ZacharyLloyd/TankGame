using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> roomPrefabs;
    public GameObject[,] grid;

    public int numCols;
    public int numRows;

    public float tileWidth = 50.0f;
    public float tileHeight = 50.0f;


    // Start is called before the first frame update
    void Start()
    {
        BuildLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BuildLevel()
    {

        //TODO:  Seed the random generator


        // Create the 2D Array
        grid = new GameObject[numCols, numRows];

        // For loops through all the rooms 
        for (int currentCol = 0; currentCol < numCols; currentCol++)
        {
            for (int currentRow = 0; currentRow < numRows; currentRow++)
            {
                // Instantiate a room
                GameObject tempRoom = Instantiate(RandomRoom());
                // Add to the grid array
                grid[currentCol, currentRow] = tempRoom;
                // Move it into position
                tempRoom.transform.position = new Vector3(currentCol * tileWidth, 0, -currentRow * tileHeight);
                // Name my room
                tempRoom.name = "Room (" + currentCol + "," + currentRow + ")";
                // Make it a child of this object
                tempRoom.GetComponent<Transform>().parent = this.gameObject.GetComponent<Transform>();

                // TODO: Based on it's location, open the appropriate doors
                Room roomScript = tempRoom.GetComponent<Room>();
                if (currentCol != 0)
                {
                    roomScript.doorWest.SetActive(false);
                }

                if (currentCol != numCols - 1)
                {
                    roomScript.doorEast.SetActive(false);
                }

                if (currentRow != 0)
                {
                    roomScript.doorNorth.SetActive(false);
                }

                if (currentRow != numRows - 1)
                {
                    roomScript.doorSouth.SetActive(false);
                }
            }
        }

    }

    public void DestroyLevel()
    {
        for (int currentRow = 0; currentRow < numRows; currentRow++)
        {
            for (int currentCol = 0; currentCol < numCols; currentCol++)
            {
                Destroy(grid[currentCol, currentRow]);
            }
        }
    }

    private GameObject RandomRoom()
    {
        int roomIndex = Random.Range(0, roomPrefabs.Count);
        return roomPrefabs[roomIndex];
    }
}
