using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Assets/Player/PlayerData")]
public class playerData : ScriptableObject
{
    /* playerData
     * Contiene todas las variables globales del jugador:
     - Vida
     - Stamina
     - Paranoia
     * Ademas de los metodos para modificarlos
     - Bajar la vida
     - Bajar la stamina
     - Recuperar la stamina con el tiempo
     etc
     *
	
    */

    // VARIABLES
    public float maxHealth;
    public float health;
    public float maxStamina;
    public float stamina;
    public float losingStaminaSpeed;
    public float paranoia;

    public void ResetData()
    {
        health = maxHealth;
        stamina = maxStamina;
        paranoia = 0f;
    }
}
