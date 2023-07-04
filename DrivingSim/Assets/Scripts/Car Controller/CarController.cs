using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f; // The speed of the car
    public float rotationSpeed = 100f;
    public float wheelrotationSpeed = 200f; // The rotation speed of the car
    public Transform[] wheelModels; // Array of wheel models to rotate

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

private void FixedUpdate()
{
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    // Move the car forward and backward
    Vector3 movement = transform.forward * moveVertical * speed * Time.deltaTime;
    rb.MovePosition(rb.position + movement);

    // Rotate the car left and right
    Quaternion rotation = Quaternion.Euler(0f, moveHorizontal * rotationSpeed * Time.deltaTime, 0f);
    rb.MoveRotation(rb.rotation * rotation);

    // Rotate the wheels based on the car's movement and turn
    RotateWheels(moveVertical, moveHorizontal);
}

private void RotateWheels(float moveVertical, float moveHorizontal)
{
    float rotationAmount = moveVertical * wheelrotationSpeed * Time.deltaTime;

    // Calculate the additional rotation amount based on the turn angle
    float additionalRotation = moveHorizontal * rotationAmount;

    // Apply the rotation to the wheels
    foreach (Transform wheel in wheelModels)
    {
        wheel.Rotate(Vector3.right, rotationAmount);
        //wheel.Rotate(Vector3.up, additionalRotation);
    }
}
}
