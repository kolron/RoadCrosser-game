using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string[] DestroyBothTags; // This array will hold the tags, that if collided with the object this script is attached to, will destory both colliders.
    [SerializeField] string[] DestroySelfOnEnemyTags; //This array holds the tags that if collided with this object, only this collider that holds the script will be destroyed.
    //the reason I made this is to add functionallity to different objects that collide, for example the upgraded cannon will not be destoryed when it collides with an enemy, 
    //while a regular shot will - if expanded, multiple tags can do different things, so this is an easy way to manage it.
    
    private void OnTriggerEnter2D(Collider2D other) {
        bool DestroyBothFlag = false;
        bool DestroySelfOnEnemyFlag = false;

        //check if its in either array
        for (int i = 0; i < DestroyBothTags.Length && (!DestroyBothFlag); i++)
        {
            if(DestroyBothTags[i] == other.tag)
            {
                DestroyBothFlag = true;
            }
        }
        for (int i = 0; i < DestroySelfOnEnemyTags.Length && !(DestroySelfOnEnemyFlag || DestroyBothFlag); i++)
        {
            if (DestroySelfOnEnemyTags[i] == other.tag)
            {
                DestroySelfOnEnemyFlag = true;
            }
        }

        //act accordingly
        if (DestroyBothFlag && enabled)
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

        else if(DestroySelfOnEnemyFlag && enabled)
        {
            Destroy(gameObject);
        }

        
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
    }
}
