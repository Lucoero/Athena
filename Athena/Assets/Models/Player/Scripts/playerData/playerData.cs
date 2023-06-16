using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class playerData : ScriptableObject
{
    /* playerData
     * Contiene todas las variables globales del jugador:
     - Vida
     - Stamina
     - Paranoia
	
    */

    // VARIABLES
    public float vida;
    public float stamina;
    public float losingStaminaSpeed;
    public float Paranoia;
}
