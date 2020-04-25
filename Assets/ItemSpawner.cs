using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSpawner : MonoBehaviour
{
    public GameObject ItemTile;
    private Vector2 movement;
    public float StartSpeed;
    public int SpaceBetweenItemTiles;
    public Transform CenterOfSquare;

    private GameObject selectedItem;
    private float currentSpeed;
    private bool spinning = false;
    private float PosX;
    void Start()
    {
        currentSpeed = 0;
        foreach (GameObject x in GameObject.FindGameObjectsWithTag("ItemTile"))
        {
            GameObject.Destroy(x);
        }
        movement.x = -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spinning)
        {
            PosX = 1000000000;
            foreach (GameObject x in GameObject.FindGameObjectsWithTag("ItemTile"))
            {
                x.GetComponent<Rigidbody2D>().MovePosition(x.GetComponent<Rigidbody2D>().position + movement * currentSpeed * Time.fixedDeltaTime);

                if (Math.Abs(transform.position.x - x.GetComponent<Transform>().position.x) < PosX)
                {
                    PosX = Math.Abs(transform.position.x - x.GetComponent<Transform>().position.x);
                }
            }
            if (PosX > SpaceBetweenItemTiles)
                SpawnOne();

            currentSpeed -= Time.deltaTime * 80;

            if (currentSpeed <= 0)
            {
                spinning = false;
                currentSpeed = 0;
                PosX = 1000000000;
                GameObject previous = GameObject.FindGameObjectWithTag("ItemTile");
                foreach (GameObject x in GameObject.FindGameObjectsWithTag("ItemTile"))
                {
                    if (Math.Abs(CenterOfSquare.position.x - x.GetComponent<Transform>().position.x) < PosX)
                    {
                        PosX = Math.Abs(CenterOfSquare.position.x - x.GetComponent<Transform>().position.x);
                        GameObject.Destroy(previous);
                        previous = x;
                        selectedItem = x;
                        x.transform.position = CenterOfSquare.position;
                    }
                    else
                    {
                        previous = x;
                        GameObject.Destroy(x);
                    }
                }

                GameObject player = GameObject.FindGameObjectWithTag("Player");

                if(selectedItem.GetComponent<ItemLootHandler>().ThisItemSlot.Equals("Boots") && selectedItem.GetComponent<ItemLootHandler>().Stat >= player.GetComponent<Player>().BootLevel)
                {
                    string upgradeName = selectedItem.GetComponent<ItemLootHandler>().RarityString + " " + selectedItem.GetComponent<ItemLootHandler>().ThisName;
                    player.GetComponent<Player>().BootHandler(upgradeName, selectedItem.GetComponent<ItemLootHandler>().Stat);
                }
                if (selectedItem.GetComponent<ItemLootHandler>().ThisItemSlot.Equals("Armour") && selectedItem.GetComponent<ItemLootHandler>().Stat >= player.GetComponent<Player>().ArmourLevel)
                {
                    string upgradeName = selectedItem.GetComponent<ItemLootHandler>().RarityString + " " + selectedItem.GetComponent<ItemLootHandler>().ThisName;
                    player.GetComponent<Player>().ArmourHandler(upgradeName, selectedItem.GetComponent<ItemLootHandler>().Stat);
                }
                if (selectedItem.GetComponent<ItemLootHandler>().ThisItemSlot.Equals("Weapon") && selectedItem.GetComponent<ItemLootHandler>().Stat >= player.GetComponent<Player>().WeaponLevel)
                {
                    string upgradeName = selectedItem.GetComponent<ItemLootHandler>().RarityString + " " + selectedItem.GetComponent<ItemLootHandler>().ThisName;
                    player.GetComponent<Player>().WeaponHandler(upgradeName, selectedItem.GetComponent<ItemLootHandler>().Stat);
                }
                if (selectedItem.GetComponent<ItemLootHandler>().ThisItemSlot.Equals("Wood"))
                {
                    player.GetComponent<Player>().WoodHandler(selectedItem.GetComponent<ItemLootHandler>().Stat);
                }
                if (selectedItem.GetComponent<ItemLootHandler>().ThisItemSlot.Equals("Garbage"))
                {
                    //nothing yet.
                }

            }
        }
    }

    public void SpawnOne()
    {
        Instantiate(ItemTile, transform.position, transform.rotation);
    }

    public void SpinTheWheel()
    {
        if(spinning) { return; }
        foreach (GameObject x in GameObject.FindGameObjectsWithTag("ItemTile"))
        {
            GameObject.Destroy(x);
        }
        SpawnOne();
        spinning = true;
        currentSpeed = StartSpeed;
    }

}
