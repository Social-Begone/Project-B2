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
    private GameObject hubEvent;

    private GameObject overWorldMenu;
    private GameObject locationMenu;

    void Start() {
        gameObject.GetComponent<Player>().LoadME();
        gameObject.GetComponent<Player>().HealthHandler(0);
        Target.x = SaveSystem.LoadPlayer().Position[0];
        Target.y = SaveSystem.LoadPlayer().Position[1];
        Target.z = SaveSystem.LoadPlayer().Position[2];
        transform.position = Target;

        currentLocation = WhereAmI();

        GameObject.FindGameObjectWithTag("PlayerPosText").GetComponent<Text>().text = currentLocation;

        hubEvent = GameObject.FindGameObjectWithTag("MapMarkerHandler");

        overWorldMenu = GameObject.FindGameObjectWithTag("CanvasOverWorld");
        overWorldMenu.GetComponent<CanvasGroup>().alpha = 1f;
        overWorldMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void Update() {
        float step = MoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target, step);

        currentLocation = WhereAmI();
        GameObject.FindGameObjectWithTag("PlayerPosText").GetComponent<Text>().text = currentLocation;

        if (currentLocation == targetLocation && ArriveOnce) {
            ArriveOnce = false;

            GameObject[] places = GameObject.FindGameObjectsWithTag(currentLocation);
            foreach (GameObject _places in places) {
                if (_places.GetComponent<Canvas>() != null) {
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

    public void WalkHere(string locationTag) {
        targetLocation = locationTag;
        ArriveOnce = true;

        LocationTag[] locations = FindObjectsOfType<LocationTag>();

        foreach (LocationTag location in locations) {
            if (location.CompareTag(locationTag)) {
                Target = location.GetComponent<RectTransform>().position;
            }
        }
    }

    public string WhereAmI() {
        string locationName = "Nowhere";
        LocationTag[] locations = FindObjectsOfType<LocationTag>();

        foreach (LocationTag location in locations) {
            var locationTransform = location.GetComponent<RectTransform>();

            if (locationTransform.position.y > transform.position.y - 1
             && locationTransform.position.y < transform.position.y + 1
             && locationTransform.position.x > transform.position.x - 1
             && locationTransform.position.x < transform.position.x + 1
             && locationTransform.position == transform.position)
                locationName = location.tag;
        }
        return locationName;
    }
}