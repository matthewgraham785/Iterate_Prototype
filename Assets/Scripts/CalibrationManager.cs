using UnityEngine;
using TMPro;

public class CalibrationManager : MonoBehaviour
{
    public static CalibrationManager Instance { get; private set; }

    [Header("Calibration UI")]
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private int totalData = 3;

    private int collectedData = 0;

    private void Awake()
    {
        Instance = this;
        UpdateCounter();
    }

    public void CollectData()
    {
        collectedData++;
        UpdateCounter();
    }

    private void UpdateCounter()
    {
        counterText.text =
            $"CALIBRATION DATA: {collectedData} / {totalData}";
    }
}
