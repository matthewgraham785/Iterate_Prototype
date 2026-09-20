using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerRespawn : MonoBehaviour
{
    [Header ("Respawn Settings")]
    public float fallThreshold = -10f;

    private Vector3 respawnPosition;
    private Quaternion respawnRotation;
    private CharacterController characterController;

    private void Start()
    {
        respawnPosition = transform.position;
        respawnRotation = transform.rotation;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        characterController.enabled = false;
        transform.position = respawnPosition;
        transform.rotation = respawnRotation;
        characterController.enabled = true;
    }

}