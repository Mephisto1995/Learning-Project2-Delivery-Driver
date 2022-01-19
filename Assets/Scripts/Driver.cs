using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steeringSpeed = 1;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steeringSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; ;

        Vector3 rotation = new Vector3(0, 0, -steerAmount);
        Vector3 move = new Vector3(0, moveAmount, 0);

        transform.Rotate(rotation);
        transform.Translate(move);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Boost":
                {
                    Debug.Log("moveSpeed: " + moveSpeed);
                    moveSpeed = boostSpeed;
                    Debug.Log("moveSpeed after boost: " + moveSpeed);
                    break;
                }

            case "Bump":
                {
                    Debug.Log("moveSpeed: " + moveSpeed);
                    moveSpeed = slowSpeed;
                    Debug.Log("moveSpeed after boost: " + moveSpeed);
                    break;
                }

            default:
                break;
        }
    }
}
