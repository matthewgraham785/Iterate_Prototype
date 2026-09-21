using UnityEngine;

public class CalibrationCollectible : MonoBehaviour
{
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
            Destroy(gameObject);
        }
    }
}
