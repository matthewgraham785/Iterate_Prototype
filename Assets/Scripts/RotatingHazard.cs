using UnityEngine;

public class RotatingHazard : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private Vector3 rotationAxis = Vector3.up;
    [SerializeField] private float rotationSpeed = 60f;

    private void Update()
    {
        transform.Rotate(
            rotationAxis.normalized * rotationSpeed * Time.deltaTime,
            Space.Self
        );
    }
}
