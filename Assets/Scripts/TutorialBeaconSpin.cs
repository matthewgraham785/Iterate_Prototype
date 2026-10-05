using UnityEngine;

public class TutorialBeaconSpin : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private Vector3 rotationAxis =
        new Vector3(0.25f, 1f, 0.15f);

    [SerializeField] private float rotationSpeed = 60f;

    private void Update()
    {
        transform.Rotate(
            rotationAxis.normalized,
            rotationSpeed * Time.deltaTime,
            Space.Self
        );
    }
}
