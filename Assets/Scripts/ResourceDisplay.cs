using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{
    // Cached References
    Text resourcesText;

    [SerializeField] int resources = 100;

    // Start is called before the first frame update
    void Start()
    {
        resourcesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        resourcesText.text = resources.ToString();
    }

    public bool haveEnoughResources(int amountToSpend)
    {
        return resources >= amountToSpend;
    }

    public void AddResources(int amountToAdd)
    {
        resources += amountToAdd;
        UpdateDisplay();
    }

    public void SpendResources(int amountToSpend)
    {
        resources -= amountToSpend;
        UpdateDisplay();
    }
}

