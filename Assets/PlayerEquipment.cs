using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipment : MonoBehaviour
{
    private Text armourText;
    private Text weaponText;
    private Text bootsText;
    void Start()
    {
        armourText = GameObject.FindGameObjectWithTag("PlayerArmour").GetComponent<Text>();
        weaponText = GameObject.FindGameObjectWithTag("PlayerWeapon").GetComponent<Text>();
        bootsText = GameObject.FindGameObjectWithTag("PlayerBoots").GetComponent<Text>();
    }

    void Update()
    {
        armourText.text = GetComponent<Player>().ArmourName + ", Lvl." + GetComponent<Player>().ArmourLevel;
        weaponText.text = GetComponent<Player>().WeaponName + ", Lvl." + GetComponent<Player>().WeaponLevel;
        bootsText.text = GetComponent<Player>().BootName + ", Lvl." + GetComponent<Player>().BootLevel;
    }
}
