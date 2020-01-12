using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;

    [Header("Effects")]
    [Range(0, 1)] [SerializeField] float volume = .5f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] GameObject deathVFX;


    public void DealDamage(float damageDealt)
    {
        health -= damageDealt;
        if (health <= 0)
        {
            Die();
            Destroy(gameObject);
        }
    }

    #region Effects


    public void Die()
    {
        Debug.Log("Die: " + name);
        TriggerDeathVFX();
        PlayDeathSFX();
    }

    private void TriggerDeathVFX()
    {
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 0.5f);
    }

    public IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1.5f);
        PlayDeathSFX();
        Destroy(gameObject);
    }


    private void PlayDeathSFX()
    {
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
    }
    #endregion

}
