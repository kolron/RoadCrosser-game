using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInstructions : MonoBehaviour
{
    //simple script that displays instructions once only.
    MeshRenderer renderer;
    [SerializeField] float instructionDuartion; // set how long you want the instruction to appear on the screen.
   
    //will be called by the powerup when you pick it up
    public void Start()
    {
           //get the renderer and enable it
            renderer = transform.GetComponent<MeshRenderer>();
            renderer.enabled =true;
            StartCoroutine(endInstructions());
    }
    IEnumerator endInstructions()
    {
        //disable after the duration and disable future use.
        yield return new WaitForSecondsRealtime(instructionDuartion);
        
        renderer.enabled = false;
    }

    // Update is called once per frame
   
}
