using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
public class displayHealthBar : MonoBehaviour
{
    /* displayHealthBar
     * Dado un asset de PlayerData
     * muestra la vida del personaje
     * en forma de barra en la esquina inferior izquierda de la pantalla
    */

    // VARIABLES
    public playerData playerData;
    public GameObject healthDisplayValue;

    private float health;

    // FUNCIONES
    void Start() 
    {
        health = playerData.health;
        //healthDisplayValue.text = Convert.ToString(health);
    }

    public void UpdateHealthDisplay()
    {

    }
    public void OnChangingHealth(float healthStep)
    {
        health += healthStep;
        if (health < 0)
        {
            health = 0;
        }
        else if(health > playerData.maxHealth){
            health = playerData.maxHealth;
        }
        UpdateHealthDisplay();
    }
}
