using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int MoveSpeed = 20;
    public Vector3 Target;

    private string currentLocation = "Nowhere";
    private string targetLocation = "Nowhere";
    private bool ArriveOnce = true;
    private GameObject HubEvent;

    private GameObject overWorldMenu;
    private GameObject locationMenu;

    void Start()
    {
        gameObject.GetComponent<Player>().LoadME();
        gameObject.GetComponent<Player>().HealthHandler(0);
        Target.x = SaveSystem.LoadPlayer().position[0];
        Target.y = SaveSystem.LoadPlayer().position[1];
        Target.z = SaveSystem.LoadPlayer().position[2];
        transform.position = Target;

        currentLocation = WhereAmI();

        GameObject.FindGameObjectWithTag("PlayerPosText").GetComponent<Text>().text = currentLocation;

        HubEvent = GameObject.FindGameObjectWithTag("MapMarkerHandler");

        overWorldMenu = GameObject.FindGameObjectWithTag("CanvasOverWorld");
        overWorldMenu.GetComponent<CanvasGroup>().alpha = 1f;
        overWorldMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void Update()
    {
        float step = MoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target, step);

        currentLocation = WhereAmI();
        GameObject.FindGameObjectWithTag("PlayerPosText").GetComponent<Text>().text = currentLocation;

        if (currentLocation == targetLocation && ArriveOnce)
        {
            ArriveOnce = false;

            GameObject[] places = GameObject.FindGameObjectsWithTag(currentLocation);
            foreach (GameObject _places in places)
            {
                if (_places.GetComponent<Canvas>() != null)
                {
                    overWorldMenu = GameObject.FindGameObjectWithTag("CanvasOverWorld");
                    overWorldMenu.GetComponent<CanvasGroup>().alpha = 0f;
                    overWorldMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    locationMenu = _places;
                    locationMenu.GetComponent<CanvasGroup>().alpha = 1f;
                    locationMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }
        }
    }

    public void WalkHere(string Tag)
    {
        targetLocation = Tag;
        ArriveOnce = true;

        ThisIsAPlace[] finder = FindObjectsOfType<ThisIsAPlace>();
        
        foreach (ThisIsAPlace aPlace in finder)
        {
            if (aPlace.tag == Tag)
            {
                Target = aPlace.GetComponent<RectTransform>().position;
            }
        }
    }

    public string WhereAmI()
    {
        string HereIAm = "Nowhere";
        ThisIsAPlace[] finder = FindObjectsOfType<ThisIsAPlace>();

        foreach (ThisIsAPlace _finder in finder)
        {
            var finder2 = _finder.GetComponent<RectTransform>();
            if (finder2.position.y > transform.position.y - 1)
                if (finder2.position.y < transform.position.y + 1)
                    if (finder2.position.x > transform.position.x - 1)
                        if (finder2.position.x < transform.position.x + 1)
                            if (finder2.position == transform.position)
                                    HereIAm = _finder.tag;
        }
        return HereIAm;
    }
}