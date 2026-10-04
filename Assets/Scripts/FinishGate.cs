using System.Collections;
using UnityEngine;
using TMPro;

public class FinishGate : MonoBehaviour
{
    [Header("Completion UI")]
    [SerializeField] private GameObject completionPanel;
    [SerializeField] private TMP_Text completionText;
    [SerializeField] private float warningDuration = 2.5f;

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
            Debug.LogWarning("FinishGate could not find the CalibrationManager.");
            return;
        }

        if (!CalibrationManager.Instance.HasEnoughData)
        {
            ShowIncompleteWarning();
            return;
        }

        CompleteLevel();
    }

    private void ShowIncompleteWarning()
    {
        if (completionPanel == null || completionText == null)
        {
            return;
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

        completionPanel.SetActive(false);
        warningCoroutine = null;
    }

    private void CompleteLevel()
    {
        levelCompleted = true;

        int stability = CalibrationManager.Instance.StabilityData;
        int risk = CalibrationManager.Instance.RiskData;

        string analysis;

        if (stability > risk)
        {
            analysis =
                "<color=#00FFFF>STABILITY PREFERENCE DETECTED</color>";
        }
        else if (risk > stability)
        {
            analysis =
                "<color=#FF6E14>RISK PREFERENCE DETECTED</color>";
        }
        else
        {
            analysis =
                "<color=#FFFFFF>BALANCED BEHAVIOR DETECTED</color>";
        }

        if (completionText != null)
        {
            completionText.text =
                "CALIBRATION COMPLETE\n\n" +
                analysis + "\n\n" +
                $"STABILITY DATA: {stability}\n" +
                $"RISK DATA: {risk}";
        }

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