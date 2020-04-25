using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLootHandler : MonoBehaviour
{
    public GameObject[] ItemObjects;
    public String ThisName;
    public String RarityString;
    public String ThisItemSlot;
    public int Stat;


    private int rarityInt; //0-4 where 4 is best

    void Awake()
    {
        Stat = UnityEngine.Random.Range(1, 6);
        rarityInt = 0;
        RarityString = "Low-Tier";
        Color RarityColor = new Color(0f, 0f, 0f, 0f);
        if (UnityEngine.Random.Range(0, 2) > 0)
        {
            rarityInt = 1;
            RarityString = "Common";
            RarityColor = new Color(0f, 0.5f, 0.5f, 0f);
            if (UnityEngine.Random.Range(0, 2) > 0)
            {
                rarityInt = 2;
                RarityString = "Regular";
                RarityColor = new Color(0f, 0f, 1f, 0f);
                if (UnityEngine.Random.Range(0, 3) > 1)
                {
                    rarityInt = 3;
                    RarityString = "Rare";
                    RarityColor = new Color(1f, 0f, 0f, 0f);
                    if (UnityEngine.Random.Range(0, 3) > 1)
                    {
                        rarityInt = 4;
                        RarityString = "Legendary";
                        RarityColor = new Color(1f, 1f, 0f, 0f);
                    }
                }
            }
        }

        int i = UnityEngine.Random.Range(0, ItemObjects.Length);

        if (ItemObjects[i].GetComponent<ItemInformation>().ItemSlot.Equals("Weapon") || ItemObjects[i].GetComponent<ItemInformation>().ItemSlot.Equals("Boots") || ItemObjects[i].GetComponent<ItemInformation>().ItemSlot.Equals("Armour"))
            Stat = UnityEngine.Random.Range(1, 3) + rarityInt * rarityInt * 2;
        else
            Stat = 2 + rarityInt * rarityInt * rarityInt * rarityInt;

        GetComponent<SpriteRenderer>().sprite = ItemObjects[i].GetComponent<SpriteRenderer>().sprite;
        ThisItemSlot = ItemObjects[i].GetComponent<ItemInformation>().ItemSlot;
        ThisName = ItemObjects[i].GetComponent<ItemInformation>().Name;
        gameObject.transform.Find("Rarity").GetComponent<SpriteRenderer>().color += RarityColor;
    }

    void Update()
    {
        if (Math.Abs(transform.position.x) > 500)
            Destroy(gameObject);
    }
}
