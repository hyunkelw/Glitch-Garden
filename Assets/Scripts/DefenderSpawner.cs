using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    Defender defender;

    //cached references
    ResourceDisplay resourceDisplay;
    GameObject defenderParent;

    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        resourceDisplay = FindObjectOfType<ResourceDisplay>();
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefender(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickedPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickedPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        //Debug.Log("rawWorldPos: " + rawWorldPos);
        
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }


    private void SpawnDefender(Vector2 coordinates)
    {
        //Debug.Log("coordinates: " + coordinates);
        var newDefender = Instantiate(defender, coordinates, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }

    public void SetDefender(Defender newDefender)
    {
        defender = newDefender;
    }

    private void AttemptToPlaceDefender(Vector2 coordinates)
    {
        var defenderCost = defender.GetCost();
        if(resourceDisplay.haveEnoughResources(defenderCost))
        {
            SpawnDefender(coordinates);
            resourceDisplay.SpendResources(defenderCost);
        }
    }
}
