using System.Collections;
using UnityEngine;

public class Jello : MonoBehaviour
{

    [Range(0f, 1f)]
    public float fadeToAmount = 0f;

    // Variable to hold fading speed
    public float fadingSpeed = 0.05f;

    //cached references
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject target = otherCollider.gameObject;
        //Debug.Log("collision with: " + otherCollider.name);
        if (target.GetComponent<Gravestone>())
        {
            Debug.Log("Die!");
            StartCoroutine(GetComponent<Health>().Disappear());
        }
        else if (target.GetComponent<Defender>())
        {
            Debug.Log("PassThrough!: " + otherCollider.name);
            StartCoroutine(PassThrough());
        }
    }

    private IEnumerator PassThrough()
    {
        // Getting access to Color options
        Color c = spriteRenderer.material.color;
        // Loop that runs from 1 down to desirable Alpha Channel Color amount
        for (float i = 1f; i >= fadeToAmount; i -= fadingSpeed)
        {
            // Setting values for alpha channel
            c.a = i;
            // Set color to Sprite Renderer
            spriteRenderer.material.color = c;

            // Pause to make color be changed slowly
            yield return new WaitForSeconds(fadingSpeed);
        }
    }


    //private void OnTriggerStay2D(Collider2D otherCollider)
    //{
    //    GameObject target = otherCollider.gameObject;
    //    if (target.GetComponent<Defender>() && !target.GetComponent<Gravestone>())
    //    {
    //        Debug.Log("OnTriggerStay");
    //        var spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    //        Color color = spriteRenderer.material.color;
    //        spriteRenderer.material.color = color;
    //    }
    //}

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        GameObject target = otherCollider.gameObject;
        if (target.GetComponent<Defender>())
        {
            Debug.Log("OnTriggerExit");
            //var spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            //Color color = spriteRenderer.material.color;
            //spriteRenderer.material.color = color;
            StartCoroutine(ReturnVisible());
        }

    }

    private IEnumerator ReturnVisible()
    {
        // Getting access to Color options
        Color c = spriteRenderer.material.color;

        // Loop that runs from 1 down to desirable Alpha Channel Color amount
        for (float i = c.a; i <= 1f; i += fadingSpeed)
        {
            // Setting values for alpha channel
            c.a = i;
            // Set color to Sprite Renderer
            spriteRenderer.material.color = c;

            // Pause to make color be changed slowly
            yield return new WaitForSeconds(fadingSpeed);
        }
    }

}
