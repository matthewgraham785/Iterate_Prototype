using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [Header("Movement Settings")]
    public Vector3 moveDirection = Vector3.up;
    public float movementDistance = 0.5f;
    public float movementSpeed = 1f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float movement = Mathf.Sin(Time.time * movementSpeed) 
                                    * movementDistance;

        transform.position = startPosition 
                            + moveDirection.normalized * movement;
    }
}
