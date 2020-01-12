using UnityEngine;

public class Lizard : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject target = otherCollider.gameObject;
        //Debug.Log("collision with: " + otherCollider.name);
        if (target.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(target);
        }
    }
}
