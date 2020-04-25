using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosestItemFinder : MonoBehaviour
{
    public float PosX;
    public float PosY;
    public ItemLootHandler SelectedItem;
    public Text ThatText;

    void Start()
    {
        ThatText = GameObject.FindGameObjectWithTag("Bunker").GetComponent<Text>();
    }
    void Update()
    { 
        PosX = 1000000000;
        GameObject[] find = GameObject.FindGameObjectsWithTag("ItemTile");
        if(find.Length < 1) { }
        else
        {
            foreach (GameObject x in find)
            {
                if (Math.Abs(transform.position.x - x.GetComponent<Transform>().position.x) < PosX)
                {
                    PosX = Math.Abs(transform.position.x - x.GetComponent<Transform>().position.x);
                    SelectedItem = x.GetComponent<ItemLootHandler>();
                }
            }
            ThatText.text = SelectedItem.ThisName + "\n" + SelectedItem.RarityString;
            ThatText.color = SelectedItem.transform.Find("Rarity").GetComponent<SpriteRenderer>().color;
        }
    }
}
