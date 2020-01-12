using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile, gun;

    // cached references
    AttackerSpawner myLaneSpawner;
    Animator myAnimator;
    GameObject ProjectileParent;

    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        SetLaneSpawners();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        ProjectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!ProjectileParent)
        {
            ProjectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
            //Debug.Log("pew pew!!");
            myAnimator.SetBool("isAttacking", true);
        }
        else
        {
            myAnimator.SetBool("isAttacking", false);
            //Debug.Log("Sit and wait");
        }
        
    }

    private bool IsAttackerInLane()
    {
        if(!myLaneSpawner)
        {
            return false;
        }
        return myLaneSpawner.transform.childCount > 0;
    }

    public void SetLaneSpawners()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in attackerSpawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if(isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }

    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity) as GameObject;
        newProjectile.transform.parent = ProjectileParent.transform;
    }
}
