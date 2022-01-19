using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float packageDestroyDelay = 0;
    Color32 defaultDriverColor;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultDriverColor = spriteRenderer.color;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.tag)
        {
            case "Package":
                {
                    if (!hasPackage)
                    {
                        Debug.Log("Package picked up!");
                        Destroy(other.gameObject, packageDestroyDelay);
                        spriteRenderer.color = other.GetComponent<SpriteRenderer>().color;
                    }

                    hasPackage = true;

                    break;
                }

            case "Client":
                {
                    if (hasPackage)
                    {
                        Debug.Log("Package delivered!");
                        spriteRenderer.color = defaultDriverColor;
                    }
                    hasPackage = false;
                    break;
                }

            default:
                {
                    hasPackage = false;
                    break;
                }
        }
    }
}
