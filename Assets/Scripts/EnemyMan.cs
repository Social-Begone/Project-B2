using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMan : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Player>().LoadME();
        int CurrentDay = gameObject.GetComponent<Player>().DayCounter;
        int health = Random.Range(10 + CurrentDay, 20 + CurrentDay);
        int weapon = Random.Range(1 + CurrentDay, 2 + CurrentDay);
        int armour = Random.Range(1 + CurrentDay, 2 + CurrentDay);

        string enemyName = "Wolf";
        string weaponName = "Claws";
        string armourName = "Fur";

        GameObject.FindGameObjectWithTag("EnemyWeaponStat").GetComponent<Text>().text = weapon.ToString();
        GameObject.FindGameObjectWithTag("EnemyArmourStat").GetComponent<Text>().text = armour.ToString();

        GameObject.FindGameObjectWithTag("EnemyHealth").GetComponent<Text>().text = health.ToString() + " HP";
        GameObject.FindGameObjectWithTag("EnemyName").GetComponent<Text>().text = enemyName;
        GameObject.FindGameObjectWithTag("EnemyWeapon").GetComponent<Text>().text = weaponName;
        GameObject.FindGameObjectWithTag("EnemyArmour").GetComponent<Text>().text = armourName;
    }
}
