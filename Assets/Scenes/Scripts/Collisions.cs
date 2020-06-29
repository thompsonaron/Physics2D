using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Collisions : MonoBehaviour
{
    public GameObject[] collidedObjects;
    public GameObject[] waters;
    public bool wasInWater = false;
    public float Vdisplaced;
    public float offset = 0.05f;
    public float correction = 0.02f;

    private void Awake()
    {
        collidedObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        waters = GameObject.FindGameObjectsWithTag("Water");
    }

    public bool CheckForCollisionYDown(GameObject objectToCheckCollisionsWith)
    {
        for (int i = 0; i < collidedObjects.Length; i++)
        {
            float objBottomXAxis = objectToCheckCollisionsWith.transform.position.y - (objectToCheckCollisionsWith.transform.localScale.y / 2);
            float objTopXAxis = objectToCheckCollisionsWith.transform.position.y + (objectToCheckCollisionsWith.transform.localScale.y / 2);
            float obstacleBottomXAxis = collidedObjects[i].transform.position.y - (collidedObjects[i].transform.localScale.y / 2);
            float obstacleTopXAxis = collidedObjects[i].transform.position.y + (collidedObjects[i].transform.localScale.y / 2);

            float objLeftYAxis = objectToCheckCollisionsWith.transform.position.x - (objectToCheckCollisionsWith.transform.localScale.x / 2);
            float objRightYAxis = objectToCheckCollisionsWith.transform.position.x + (objectToCheckCollisionsWith.transform.localScale.x / 2);
            float obstacleLeftYAxis = collidedObjects[i].transform.position.x - (collidedObjects[i].transform.localScale.x / 2);
            float obstacleRightYAxis = collidedObjects[i].transform.position.x + (collidedObjects[i].transform.localScale.x / 2);

            if (objBottomXAxis - offset <= obstacleTopXAxis && objTopXAxis > obstacleTopXAxis && ((objLeftYAxis < obstacleRightYAxis) && (objRightYAxis > obstacleLeftYAxis)))
            {
                Debug.Log("ColD");
                objectToCheckCollisionsWith.transform.position = new Vector2(transform.position.x, collidedObjects[i].transform.position.y + collidedObjects[i].transform.localScale.y / 2 + objectToCheckCollisionsWith.transform.localScale.y / 2 + correction);
                wasInWater = false;
                return true;
            }
        }
        return false;
    }
    public bool CheckForCollisionYUp(GameObject objectToCheckCollisionsWith)
    {
        for (int i = 0; i < collidedObjects.Length; i++)
        {
            float objBottomXAxis = objectToCheckCollisionsWith.transform.position.y - (objectToCheckCollisionsWith.transform.localScale.y / 2);
            float objTopXAxis = objectToCheckCollisionsWith.transform.position.y + (objectToCheckCollisionsWith.transform.localScale.y / 2);
            float obstacleBottomXAxis = collidedObjects[i].transform.position.y - (collidedObjects[i].transform.localScale.y / 2);
            float obstacleTopXAxis = collidedObjects[i].transform.position.y + (collidedObjects[i].transform.localScale.y / 2);

            float objLeftYAxis = objectToCheckCollisionsWith.transform.position.x - (objectToCheckCollisionsWith.transform.localScale.x / 2);
            float objRightYAxis = objectToCheckCollisionsWith.transform.position.x + (objectToCheckCollisionsWith.transform.localScale.x / 2);
            float obstacleLeftYAxis = collidedObjects[i].transform.position.x - (collidedObjects[i].transform.localScale.x / 2);
            float obstacleRightYAxis = collidedObjects[i].transform.position.x + (collidedObjects[i].transform.localScale.x / 2);

            if (objTopXAxis + offset >= obstacleBottomXAxis && objBottomXAxis < obstacleBottomXAxis && ((objLeftYAxis < obstacleRightYAxis) && (objRightYAxis > obstacleLeftYAxis)))
            {
                Debug.Log("ColU");
                objectToCheckCollisionsWith.transform.position = new Vector2(transform.position.x, collidedObjects[i].transform.position.y - collidedObjects[i].transform.localScale.y / 2 - objectToCheckCollisionsWith.transform.localScale.y / 2 - correction);
                return true;
            }
        }

        return false;
    }

    public bool CheckForCollisionXRight(GameObject objectToCheckCollisionsWith)
    {
        for (int i = 0; i < collidedObjects.Length; i++)
        {

            float objBottomXAxis = objectToCheckCollisionsWith.transform.position.y - (objectToCheckCollisionsWith.transform.localScale.y / 2);
            float objTopXAxis = objectToCheckCollisionsWith.transform.position.y + (objectToCheckCollisionsWith.transform.localScale.y / 2);
            float obstacleBottomXAxis = collidedObjects[i].transform.position.y - (collidedObjects[i].transform.localScale.y / 2);
            float obstacleTopXAxis = collidedObjects[i].transform.position.y + (collidedObjects[i].transform.localScale.y / 2);

            float objLeftYAxis = objectToCheckCollisionsWith.transform.position.x - (objectToCheckCollisionsWith.transform.localScale.x / 2);
            float objRightYAxis = objectToCheckCollisionsWith.transform.position.x + (objectToCheckCollisionsWith.transform.localScale.x / 2);
            float obstacleLeftYAxis = collidedObjects[i].transform.position.x - (collidedObjects[i].transform.localScale.x / 2);
            float obstacleRightYAxis = collidedObjects[i].transform.position.x + (collidedObjects[i].transform.localScale.x / 2);

            if (objBottomXAxis < obstacleTopXAxis && objTopXAxis > obstacleBottomXAxis && (objRightYAxis + offset >= obstacleLeftYAxis) && (objLeftYAxis < obstacleLeftYAxis))
            {
                Debug.Log("ColR");
                objectToCheckCollisionsWith.transform.position = new Vector2(collidedObjects[i].transform.position.x - collidedObjects[i].transform.localScale.x / 2 - objectToCheckCollisionsWith.transform.localScale.x / 2 - correction, transform.position.y);
                return true;
            }
        }
        return false;
    }
    public bool CheckForCollisionXLeft(GameObject objectToCheckCollisionsWith)
    {
        for (int i = 0; i < collidedObjects.Length; i++)
        {
            float objBottomXAxis = objectToCheckCollisionsWith.transform.position.y - (objectToCheckCollisionsWith.transform.localScale.y / 2);
            float objTopXAxis = objectToCheckCollisionsWith.transform.position.y + (objectToCheckCollisionsWith.transform.localScale.y / 2);
            float obstacleBottomXAxis = collidedObjects[i].transform.position.y - (collidedObjects[i].transform.localScale.y / 2);
            float obstacleTopXAxis = collidedObjects[i].transform.position.y + (collidedObjects[i].transform.localScale.y / 2);

            float objLeftYAxis = objectToCheckCollisionsWith.transform.position.x - (objectToCheckCollisionsWith.transform.localScale.x / 2);
            float objRightYAxis = objectToCheckCollisionsWith.transform.position.x + (objectToCheckCollisionsWith.transform.localScale.x / 2);
            float obstacleLeftYAxis = collidedObjects[i].transform.position.x - (collidedObjects[i].transform.localScale.x / 2);
            float obstacleRightYAxis = collidedObjects[i].transform.position.x + (collidedObjects[i].transform.localScale.x / 2);

            if (objBottomXAxis < obstacleTopXAxis && objTopXAxis > obstacleBottomXAxis && (objLeftYAxis - offset <= obstacleRightYAxis) && (objRightYAxis > obstacleRightYAxis))
            {
                Debug.Log("ColL");
                objectToCheckCollisionsWith.transform.position = new Vector2(collidedObjects[i].transform.position.x + collidedObjects[i].transform.localScale.x / 2 + objectToCheckCollisionsWith.transform.localScale.x / 2 + correction, transform.position.y);
                return true;
            }
        }
        return false;
    }

    public bool CheckCollisionWithWaterDown(GameObject objectToCheckCollisionsWith)
    {
        //float objBottomXAxis = objectToCheckCollisionsWith.transform.position.y - (objectToCheckCollisionsWith.transform.localScale.y / 2);
        //float objTopXAxis = objectToCheckCollisionsWith.transform.position.y + (objectToCheckCollisionsWith.transform.localScale.y / 2);
        //float obstacleBottomXAxis = collidedObjects[i].transform.position.y - (collidedObjects[i].transform.localScale.y / 2);
        //float obstacleTopXAxis = collidedObjects[i].transform.position.y + (collidedObjects[i].transform.localScale.y / 2);

        //float objLeftYAxis = objectToCheckCollisionsWith.transform.position.x - (objectToCheckCollisionsWith.transform.localScale.x / 2);
        //float objRightYAxis = objectToCheckCollisionsWith.transform.position.x + (objectToCheckCollisionsWith.transform.localScale.x / 2);
        //float obstacleLeftYAxis = collidedObjects[i].transform.position.x - (collidedObjects[i].transform.localScale.x / 2);
        //float obstacleRightYAxis = collidedObjects[i].transform.position.x + (collidedObjects[i].transform.localScale.x / 2);
        for (int i = 0; i < waters.Length; i++)
        {

            float objBottomXAxis = objectToCheckCollisionsWith.transform.position.y - (objectToCheckCollisionsWith.transform.localScale.y / 2);
            float objTopXAxis = objectToCheckCollisionsWith.transform.position.y + (objectToCheckCollisionsWith.transform.localScale.y / 2);
            float obstacleBottomXAxis = waters[i].transform.position.y - (waters[i].transform.localScale.y / 2);
            float obstacleTopXAxis = waters[i].transform.position.y + (waters[i].transform.localScale.y / 2);

            float objLeftYAxis = objectToCheckCollisionsWith.transform.position.x - (objectToCheckCollisionsWith.transform.localScale.x / 2);
            float objRightYAxis = objectToCheckCollisionsWith.transform.position.x + (objectToCheckCollisionsWith.transform.localScale.x / 2);
            float obstacleLeftYAxis = waters[i].transform.position.x - (waters[i].transform.localScale.x / 2);
            float obstacleRightYAxis = waters[i].transform.position.x + (waters[i].transform.localScale.x / 2);

            //    if (objBottomXAxis - offset <= obstacleTopXAxis && objTopXAxis > obstacleTopXAxis && ((objLeftYAxis <= obstacleRightYAxis) && (objRightYAxis >= obstacleLeftYAxis)))

            //if ((object1.transform.position.y - object1.transform.localScale.y <= waters[i].transform.position.y + waters[i].transform.localScale.y)
            //    && (object1.transform.position.x >= waters[i].transform.position.x - waters[i].transform.localScale.x)
            //    && (object1.transform.position.x <= waters[i].transform.position.x + waters[i].transform.localScale.x))
            //    if (objectToCheckCollisionsWith.transform.position.y - objectToCheckCollisionsWith.transform.localScale.y / 2 <= waters[i].transform.position.y + waters[i].transform.localScale.y / 2)
            if (objBottomXAxis - offset <= obstacleTopXAxis && objTopXAxis > obstacleTopXAxis && ((objLeftYAxis <= obstacleRightYAxis) && (objRightYAxis >= obstacleLeftYAxis)))
            {
                if (objectToCheckCollisionsWith.transform.name == "Player")
                {
                    Debug.Log("Watercol");
                    Vdisplaced = Mathf.Abs((objectToCheckCollisionsWith.transform.position.y - objectToCheckCollisionsWith.transform.localScale.y / 2) - (waters[i].transform.position.y + waters[i].transform.localScale.y / 2));
                    Debug.Log("Displaced: " + Vdisplaced);

                    if (Vdisplaced > objectToCheckCollisionsWith.GetComponent<Player2D>().volumeOfObject)
                    {
                        Vdisplaced = objectToCheckCollisionsWith.GetComponent<Player2D>().volumeOfObject;
                    }
                }
                wasInWater = true;
                return true;
            }

        }
        return false;
    }
    public bool CheckCollisionWithWaterUp(GameObject object1)
    {
        for (int i = 0; i < waters.Length; i++)
        {
            if ((object1.transform.position.y >= waters[i].transform.position.y + waters[i].transform.localScale.y / 2)
                && (object1.transform.position.x >= waters[i].transform.position.x - waters[i].transform.localScale.x / 2)
                && (object1.transform.position.x <= waters[i].transform.position.x + waters[i].transform.localScale.x / 2)
                && wasInWater)
            {
                return true;
            }
        }
        return false;
    }
}