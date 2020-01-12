using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    LivesDisplay livesDisplay;

    private void Awake()
    {
        livesDisplay = FindObjectOfType<LivesDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Debug.Log("collision with: " + otherCollider.name);
        livesDisplay.LoseLife();
        Destroy(otherCollider.gameObject);
    }
}
