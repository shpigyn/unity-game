using UnityEngine;

public class StaminaComponents : MonoBehaviour
{
    public float currentStamina;
    public float maxStamina;

    public float regenStamina;

    void Update()
    {
        regen();
    }

    void regen() 
    {
        if (currentStamina != maxStamina)
        {
        currentStamina += regenStamina * Time.deltaTime;
        currentStamina = currentStamina > maxStamina ? maxStamina : currentStamina;
        } 
    }
}
