using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    Color32 IDLE_COLOR = new Color32(104, 104, 104, 255);
    [SerializeField] Defender defenderPrefab;
    [SerializeField] bool preSelected = false;

    //Cached references
    DefenderSpawner defenderSpawner;
    Tooltip tooltip;

    private void Awake()
    {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
        tooltip = FindObjectOfType<Tooltip>();
        if (preSelected)
        {
            ShowButtonAsSelected();
        }
    }

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogError(name + " has no cost text!");
        }
        else
        {
            costText.text = defenderPrefab.GetCost().ToString();
        }

    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = IDLE_COLOR;
        }
        ShowButtonAsSelected();
    }

    private void ShowButtonAsSelected()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        SetDefender();
    }

    private void SetDefender()
    {
        defenderSpawner.SetDefender(defenderPrefab);
    }

    private void OnMouseOver()
    {
        Debug.Log("Entered the OnPointer");
        tooltip.ShowTooltip(name);
    }

    private void OnMouseExit()
    {
        Debug.Log("Exited the button: " + name);
        tooltip.HideTooltip();
    }
}
