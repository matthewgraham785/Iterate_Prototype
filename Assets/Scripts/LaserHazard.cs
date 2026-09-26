using UnityEngine;

public class LaserHazard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerRespawn playerRespawn =
            other.GetComponentInParent<PlayerRespawn>();

        if (playerRespawn != null)
        {
            playerRespawn.Respawn();
        }
    }
}