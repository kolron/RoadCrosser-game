using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/**
 * Represents an object that has a given amount of lives, and is destroyed when the number of lives becomes 0.
 */
public class HealthSystem : MonoBehaviour
{

    [SerializeField] int lives;
    [SerializeField] string sceneName;
    private int bulletDamage = 1;
    //used to show how many lives players have
    [SerializeField] NumberField scoreField;

    //Reduce lives whenever player is hit by a car or by a bullet, on death, the other player wins
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Car" || other.tag == "Bullet")
        {
            Damage(bulletDamage);   
            
           
        }
    }
    //Reduce player lives by damage and display it.
    public void Damage(int damage) {
        scoreField.AddNumber(-damage);
        lives -= damage;
        if (lives==0) {
            Debug.Log("Game Over");
            SceneManager.LoadScene(sceneName);
        }
    }

    public int getLives()
    {
        return this.lives;
    }

    
}
