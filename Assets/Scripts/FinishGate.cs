using UnityEngine;

public class FinishGate : MonoBehaviour
{
    [Header("Completion UI")]
    [SerializeField] private GameObject completionPanel;

    private bool levelCompleted = false;

    private void Start()
    {
        Time.timeScale = 1f;

        if (completionPanel != null)
        {
            completionPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (levelCompleted || !other.CompareTag("Player"))
        {
            return;
        }

        levelCompleted = true;

        if (completionPanel != null)
        {
            completionPanel.SetActive(true);
        }

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}