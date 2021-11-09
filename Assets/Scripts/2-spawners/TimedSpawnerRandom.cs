using System.Collections;
using UnityEngine;

/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class TimedSpawnerRandom: MonoBehaviour {
    //sprite array for different car sprites
    private Sprite[] textures;
    SpriteRenderer renderer;

    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] float RotationOnY = 180;
    //float RotationOnX = 0;
    //float RotationOnZ = 0;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 3f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")] [SerializeField] float maxXDistance = 0.5f;

    void Start() {
        //Get all the possible sprites for the cars
        textures = Resources.LoadAll<Sprite>("Images/Cars");
        
        this.StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine() {
        while (true) {
            
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawns);
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y,
                transform.position.z);

            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
            newObject.transform.localRotation *= Quaternion.Euler(0, RotationOnY, 0);
            //Get the renderer for the created object, and get a random sprite from the array to use as it's sprite.
            renderer = newObject.GetComponent<SpriteRenderer>();
            renderer.sprite = textures[Random.Range(0, textures.Length)];
            
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
        }
    }
}
