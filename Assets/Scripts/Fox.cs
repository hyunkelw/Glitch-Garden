using UnityEngine;

public class Fox : MonoBehaviour
{

    public void Jump()
    {
        GetComponent<Animator>().SetTrigger("Jump Trigger");
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject target = otherCollider.gameObject;
        //Debug.Log("collision with: " + otherCollider.name);
        if (target.GetComponent<Gravestone>())
        {
            Jump();
        }
        else if (target.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(target);
        }
    }
}
