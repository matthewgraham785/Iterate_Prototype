using UnityEngine;

public class CalibrationCollectible : MonoBehaviour
{
    [Header("Pickup Audio")]
    [SerializeField] private AudioClip pickupSound;
    [SerializeField, Range(0f, 1f)] private float pickupVolume = 0.5f;

    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (collected)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            collected = true;

            CalibrationManager.Instance.CollectData();

            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(
                    pickupSound,
                    transform.position,
                    pickupVolume
                );
            }

            Destroy(gameObject);
        }
    }
}