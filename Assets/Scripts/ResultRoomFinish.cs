using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultRoomFinish : MonoBehaviour
{
    [Header("Completion UI")]
    [SerializeField] private GameObject completionPanel;
    [SerializeField] private TMP_Text completionText;

    [Header("Result Message")]
    [TextArea(3, 6)]
    [SerializeField] private string completionMessage =
        "STABLE ITERATION COMPLETE\n\n" +
        "Collected calibration data produced a stable test environment.";

    [Header("Scene Settings")]
    [SerializeField] private string mainMenuSceneName = "MainMenu";

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

        if (completionText != null)
        {
            completionText.text = completionMessage;
        }

        if (completionPanel != null)
        {
            completionPanel.SetActive(true);
        }

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartRoom()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}