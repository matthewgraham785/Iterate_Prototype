using UnityEngine;
using TMPro;

public class CalibrationManager : MonoBehaviour
{
    public static CalibrationManager Instance { get; private set; }

    [Header("Calibration UI")]
    [SerializeField] private TMP_Text counterText;

    [Header("Data Requirements")]
    [SerializeField] private int totalStabilityData = 2;
    [SerializeField] private int totalRiskData = 3;
    [SerializeField] private int requiredDataToFinish = 3;

    private int collectedStabilityData = 0;
    private int collectedRiskData = 0;

    public int StabilityData => collectedStabilityData;
    public int RiskData => collectedRiskData;
    public int TotalCollected =>
        collectedStabilityData + collectedRiskData;

    public bool HasEnoughData =>
        TotalCollected >= requiredDataToFinish;

    private void Awake()
    {
        Instance = this;
        UpdateCounter();
    }

    public void CollectData(CalibrationDataType dataType)
    {
        if (dataType == CalibrationDataType.Stability)
        {
            collectedStabilityData++;
        }
        else
        {
            collectedRiskData++;
        }

        UpdateCounter();
    }

    private void UpdateCounter()
    {
        if (counterText == null)
        {
            return;
        }

        counterText.text =
    $"<color=#00FFFF>STABILITY DATA: {collectedStabilityData} / {totalStabilityData}</color>\n" +
    $"<color=#FF6E14>RISK DATA: {collectedRiskData} / {totalRiskData}</color>";
    }
}
