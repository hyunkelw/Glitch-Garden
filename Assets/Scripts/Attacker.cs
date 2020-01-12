using UnityEngine;

public class Attacker : MonoBehaviour
{
    //[Header("Attacker Data")]
    //[SerializeField] float health = 100f;
    //[SerializeField] int pointsAwarded = 100;


    float movementSpeed = 0f;
    GameObject currentTarget;

    //Cached References
    Animator myAnimator;


    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
        UpdateAnimationStatus();
    }

    private void UpdateAnimationStatus()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float newSpeed)
    {
        movementSpeed = newSpeed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        var health = currentTarget.GetComponent<Health>();
        if (health)
        {
            //Debug.Log("dealing damage to: " + currentTarget);
            health.DealDamage(damage);
        }
    }

    private void OnDestroy()
    {
        var levelController = FindObjectOfType<LevelController>();
        if (levelController)
        {
            levelController.AttackerKilled();
        }
    }

}
