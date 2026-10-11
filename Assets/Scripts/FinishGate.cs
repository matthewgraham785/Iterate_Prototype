using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishGate : MonoBehaviour
{
    [Header("Warning UI")]
    [SerializeField] private GameObject completionPanel;
    [SerializeField] private TMP_Text completionText;
    [SerializeField] private GameObject completionActions;
    [SerializeField] private float warningDuration = 2.5f;

    [Header("Result Rooms")]
    [SerializeField] private string easyRoomSceneName = "EasyResultRoom";
    [SerializeField] private string hardRoomSceneName = "HardResultRoom";

    private bool levelCompleted = false;
    private Coroutine warningCoroutine;

    private void Start()
    {
        Time.timeScale = 1f;

        if (completionText == null && completionPanel != null)
        {
            completionText =
                completionPanel.GetComponentInChildren<TMP_Text>(true);
        }

        if (completionActions != null)
        {
            completionActions.SetActive(false);
        }

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

        if (CalibrationManager.Instance == null)
        {
            Debug.LogWarning(
                "FinishGate could not find the CalibrationManager."
            );

            return;
        }

        if (!CalibrationManager.Instance.HasEnoughData)
        {
            ShowIncompleteWarning();
            return;
        }

        LoadResultRoom();
    }

    private void ShowIncompleteWarning()
    {
        if (completionPanel == null || completionText == null)
        {
            Debug.LogWarning(
                "FinishGate is missing its warning panel or warning text."
            );

            return;
        }

        if (completionActions != null)
        {
            completionActions.SetActive(false);
        }

        completionText.text =
            "<color=#FF6E14>INSUFFICIENT CALIBRATION DATA</color>\n" +
            "COLLECT AT LEAST 3 DATA SHARDS";

        completionPanel.SetActive(true);

        if (warningCoroutine != null)
        {
            StopCoroutine(warningCoroutine);
        }

        warningCoroutine = StartCoroutine(HideWarning());
    }

    private IEnumerator HideWarning()
    {
        yield return new WaitForSeconds(warningDuration);

        if (completionPanel != null)
        {
            completionPanel.SetActive(false);
        }

        warningCoroutine = null;
    }

    private void LoadResultRoom()
    {
        levelCompleted = true;
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (CalibrationManager.Instance.HasAllData)
        {
            SceneManager.LoadScene(hardRoomSceneName);
        }
        else
        {
            SceneManager.LoadScene(easyRoomSceneName);
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}