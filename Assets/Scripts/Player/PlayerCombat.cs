using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Player>().LoadME();
        GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Text>().text = (gameObject.GetComponent<Player>().Health.ToString() + " HP");
        GameObject.FindGameObjectWithTag("PlayerWeapon").GetComponent<Text>().text = gameObject.GetComponent<Player>().WeaponName;
        GameObject.FindGameObjectWithTag("PlayerArmour").GetComponent<Text>().text = gameObject.GetComponent<Player>().ArmourName;
    }
    void Update()
    {
        
    }
}
