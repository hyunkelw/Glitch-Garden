using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int currencyCost = 100;

    private void Start()
    {
        //Debug.Log("Spawning in: " + transform.position);
    }

    public int GetCost()
    {
        return currencyCost;
    }

    public void AddResources(int amountToAdd)
    {
        FindObjectOfType<ResourceDisplay>().AddResources(amountToAdd);
    }
}
