using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0f, 720f)][SerializeField] float rotationSpeed;
    [Range(0f, 10f)][SerializeField] float movementSpeed;

    [SerializeField] float damage = 100;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * movementSpeed, Space.World);
        //transform.RotateAround(transform.position, Vector3.back, rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        if (health && attacker)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        
    }

}
