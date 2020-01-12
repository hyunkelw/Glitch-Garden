using UnityEngine;

public class Gravestone : MonoBehaviour
{

    private void OnCollisionStay2D(Collision2D otherCollider)
    {
        Attacker attacker = otherCollider.gameObject.GetComponent<Attacker>();
        if(attacker)
        {
            // TO DO: Add animation
        }
    }
}
