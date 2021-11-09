using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcaterRotator : MonoBehaviour
{
    //refrences for the object.
    private SpriteRenderer renderer;
    private KeyboardMover mover;
   
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        mover = GetComponent<KeyboardMover>();
    }

    //Once the key is pressed, load the correct sprite according to the player
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0|| Input.GetAxis("Vertical") != 0)
        {
            string playerDirection = mover.playerRotation;
            //load the correct sprtie from the resource folder.
            string spriteName = $"Images/Player/look{playerDirection}";
            renderer.sprite = Resources.Load<Sprite>(spriteName);
        }
    }
}
