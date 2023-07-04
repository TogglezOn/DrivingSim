using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float smoothness = 0.5f; // The smoothness of the camera movement
    public float distance = 5f; // The distance behind the car
    public float height = 2f; // The height above the car
    public float lookAheadDistance = 2f; // The distance to look ahead of the car
    public float rotationSpeed = 3f; // The speed of camera rotation

    private Vector3 offset; // The initial offset between the camera and the target
    private bool isMouseDragging; // Flag to indicate if mouse dragging is active
    private Vector3 previousMousePosition; // Previous mouse position for calculating the delta movement

    private void Start()
    {
        offset = new Vector3(0f, height, -distance);
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDragging = true;
            previousMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;
        }

        if (isMouseDragging)
        {
            Vector3 mouseDelta = Input.mousePosition - previousMousePosition;
            float rotationAmount = mouseDelta.x * rotationSpeed * Time.deltaTime;
            transform.RotateAround(target.position, Vector3.up, rotationAmount);

            previousMousePosition = Input.mousePosition;
        }
        else
        {
            Vector3 targetPosition = target.position + target.forward * -distance + Vector3.up * height;
            Vector3 lookAheadPosition = target.position + target.forward * lookAheadDistance;

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);
            transform.LookAt(lookAheadPosition);
        }
    }
}
