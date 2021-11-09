using TMPro;
using UnityEngine;

/**
 * This component should be attached to a TextMeshPro object.
 * It allows to feed an integer number to the text field.
 */
[RequireComponent(typeof(TextMeshPro))]
public class NumberField : MonoBehaviour
{
    private int lastLife = 1;
    HealthSystem healthSystem;
    private int number;

    void Start()
    {   //Set the number to be the lives player start with
        healthSystem = transform.parent.GetComponent<HealthSystem>();
        number = healthSystem.getLives();
        GetComponent<TextMeshPro>().text = number.ToString();
    }

    public int GetNumber()
    {
        return this.number;
    }

    public void SetNumber(int newNumber)
    {
        //ensure we don't display below 0
        if (newNumber < lastLife)
        {
            this.number = lastLife;
        }
        else
        {
            this.number = newNumber;
        }
        GetComponent<TextMeshPro>().text = newNumber.ToString();
    }

    public void AddNumber(int toAdd)
    {
        SetNumber(this.number + toAdd);
    }
}
