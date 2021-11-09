using UnityEngine;
using System.Collections;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 * This class orignally inherited the KeyboardSpawner class, but it caused some issues so I optd to remove it.
 */
public class LaserShooter : MonoBehaviour
{
    [SerializeField]  KeyCode keyToPress;
    [SerializeField]  GameObject prefabToSpawn; //Array that holds which prefabs we want to spawn, we will spawn by index. the best way to do this is to make this a struct simulating a hashmap.
    [SerializeField] float velocityOfSpawnedObject;
    
    private  Vector3 bulletDirection;

    //used to set the positional offset of the bullet spawn otherwise bullet damages the player.
    private float positionOffset = 1f;
    private Vector3 positionOffsetX;
    private Vector3 positionOffsetY;

    //used to reset bullet directon
    private float zeroVectorPlane = 0;
    


    //Added a bool to indicate if we want to use the laser cannon powerup or not.
    [Tooltip("Fire between shots in seconds")] [SerializeField] protected float fireRate = 0.5f;
    private float nextFireTime;
   
    //Most complicated function of our code.
    //It allows the player to shoot in each Direction.
    protected GameObject spawnShot()
    {
       //Get the Direction of where the player is looking from the KeyboardMover
        var playerRotation = GetComponent<KeyboardMover>().playerRotation;
        //Same Prefab, Different sprites for each Direction.
        string spritename = $"Images/Blasts/blast{playerRotation}";
        
        
        GameObject newObject;
        Vector3 positionOfSpawnedObject = transform.position;  // span at the containing object position.
        Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
        
        //Fire the correct sprite, in the correct direcion, with the correct positional offset depending on where you look.
        if (playerRotation == "up")
        {
            //Spawn the prefab
            newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject + positionOffsetY, rotationOfSpawnedObject);
            //render the correct Image
            newObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(spritename);
            //And set the direciton vector for the bullet
            bulletDirection.y = velocityOfSpawnedObject;
        }
        else if (playerRotation == "down")
        {
            newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject -  new Vector3(0, positionOffset, 0), rotationOfSpawnedObject);
            newObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(spritename);
            bulletDirection.y = -velocityOfSpawnedObject;


        }
        else if (playerRotation == "left")
        {
            newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject - new Vector3(positionOffset, 0, 0), rotationOfSpawnedObject);
            newObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(spritename);
            bulletDirection.x = -velocityOfSpawnedObject;

        }
        else //Player Rotation == right
        { 
           newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject + new Vector3(positionOffset, 0, 0), rotationOfSpawnedObject);
           newObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(spritename);
            bulletDirection.x = velocityOfSpawnedObject;

        }

        //set the bulletDirection vector in the prefab mover component so it moves.
        Mover newObjectMover = newObject.GetComponent<Mover>();
        if (newObjectMover)
        {
            newObjectMover.SetVelocity(bulletDirection);
            //reset bulletDirection vector after creation
            bulletDirection.x  *= zeroVectorPlane;
            bulletDirection.y *=  zeroVectorPlane;
        }
        
        return newObject;
        
    }
   void Start()
    {
        //used to offset the bullet spawning point in the Instantiate method
        positionOffsetY.y += positionOffset;
        positionOffsetX.x += positionOffset;
    }
    void Update()
    {
        
        //shoot when key is pressed
        if (Input.GetKey(keyToPress))
        {  // and only if enough time has passed.
            if (Time.time > nextFireTime)
            {
                spawnShot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }
}
