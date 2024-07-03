using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDock : MonoBehaviour
{
    [SerializeField]
    private Transform DockingPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sub")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb == null)
                return;

            rb.velocity = Vector3.zero;
            collision.gameObject.transform.rotation = DockingPosition.rotation;
            collision.gameObject.transform.position = DockingPosition.position;
            Debug.Log("Docked");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sub")
        {
            Debug.Log("Left dock");
        }
    }
}
