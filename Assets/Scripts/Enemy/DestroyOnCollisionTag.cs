using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollisionTag : MonoBehaviour
{
    public string tagToCollide;
    public GameObject destroyEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagToCollide))
        {
            Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if(collision.gameObject.layer == 8)
        {
            Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "Tilemap" || (collision.gameObject.name == "Tilemap (1)"))
        {
            Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }


        if (collision.gameObject.CompareTag("PlayerVulnerability"))
        {
            Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

}
