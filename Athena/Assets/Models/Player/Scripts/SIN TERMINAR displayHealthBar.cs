using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class displayHealthBar : MonoBehaviour
{
    /* displayHealthBar
     * Dado un asset de PlayerData
     * muestra la vida del personaje
     * en forma de barra en la esquina inferior izquierda de la pantalla
    */

    // VARIABLES
    public playerData playerData;

    private float health;

    // FUNCIONES
    void Start() 
    {
        health = playerData.health;
    }

    
    void OnLosingHealth()
    {
        
    }
}
