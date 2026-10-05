using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class TutorialTerminal : MonoBehaviour
{
    [Header("Tutorial UI")]
    [SerializeField] private TMP_Text tutorialPrompt;
    [SerializeField] private GameObject tutorialPanel;

    private bool playerNearby = false;
    private bool tutorialOpen = false;

    private void Start()
    {
        if (tutorialPrompt != null)
        {
            tutorialPrompt.gameObject.SetActive(true);

            tutorialPrompt.text =
                "WASD / ARROW KEYS — MOVE\n" +
                "APPROACH THE AMBER TERMINAL FOR INSTRUCTIONS";
        }

        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerNearby &&
            Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (tutorialOpen)
            {
                CloseTutorial();
            }
            else
            {
                OpenTutorial();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        playerNearby = true;

        if (!tutorialOpen && tutorialPrompt != null)
        {
            tutorialPrompt.text =
                "PRESS E TO ACCESS TRIAL BRIEFING";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        playerNearby = false;

        if (!tutorialOpen && tutorialPrompt != null)
        {
            tutorialPrompt.text = "";
        }
    }

    private void OpenTutorial()
    {
        tutorialOpen = true;

        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(true);
        }

        if (tutorialPrompt != null)
        {
            tutorialPrompt.gameObject.SetActive(false);
        }

        Time.timeScale = 0f;
    }

    private void CloseTutorial()
    {
        tutorialOpen = false;

        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false);
        }

        if (tutorialPrompt != null)
        {
            tutorialPrompt.gameObject.SetActive(true);
            tutorialPrompt.text =
                "PRESS E TO ACCESS TRIAL BRIEFING";
        }

        Time.timeScale = 1f;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}