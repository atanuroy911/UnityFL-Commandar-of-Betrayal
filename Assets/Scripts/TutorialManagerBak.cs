using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class TutorialManagerBak : MonoBehaviour
{
    public GameObject instructionsPanel;
    public TextMeshProUGUI instructionsText;
    public Button continueButton;
    public GameObject blurCamObj; // Reference to the BlurCam camera
    public GameObject labelUI; // Reference to the LabelUI GameObject

    public TextMeshProUGUI scoreObject;


    private bool isPaused = true;
    private bool inputReceived = false;
    private TutorialStage currentStage;

    // Enum to represent different stages of the tutorial
    private enum TutorialStage
    {
        Movement,
        CollectDiamond,
        GhostAbility,
        GhostAbility2,
        CollectDiamond2,
        Finish
    }

    void Start()
    {
        PauseGameWithBlur();
        currentStage = TutorialStage.Movement;
        SetInstructions("Press Arrow keys to move");
        continueButton.onClick.AddListener(ContinueGame);
    }

    void PauseGameWithBlur()
    {
        Time.timeScale = 0f; // Pause the game when it starts
        instructionsPanel.SetActive(true);
        blurCamObj.SetActive(true);
        labelUI.SetActive(false);
        isPaused = true;

    }

    void ContinueGame()
    {
        isPaused = false;
        instructionsPanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        blurCamObj.SetActive(false);
        labelUI.SetActive(true); // Enable LabelUI
        inputReceived = false;

        // Move to the next stage
        switch (currentStage)
        {
            case TutorialStage.Movement:
                currentStage = TutorialStage.CollectDiamond;
                StartCoroutine(ShowInstructionsAfterDelay("Collect the diamond using arrow keys", 2f));
                break;
            case TutorialStage.CollectDiamond:
                Debug.Log("CollectDiamond");
                break;
            case TutorialStage.GhostAbility:
                Debug.Log("GhostAbility");
                currentStage = TutorialStage.GhostAbility2;
                StartCoroutine(ShowInstructionsAfterDelay("You can only use the Ghost ability Once", 2f));
                break;
            case TutorialStage.GhostAbility2:
                currentStage = TutorialStage.CollectDiamond2;
                StartCoroutine(ShowInstructionsAfterDelay("Collect the second Diamond", 2f));
                break;
            case TutorialStage.CollectDiamond2:
                break;
            case TutorialStage.Finish:
                // StartCoroutine(ShowInstructionsAfterDelay("Well Done! Now go to Exit", 2f));
                break;

        }
    }

    IEnumerator ShowInstructionsAfterDelay(string message, float delay)
    {
        yield return new WaitForSeconds(delay);
        PauseGameWithBlur();
        SetInstructions(message);
    }

    void SetInstructions(string message)
    {
        instructionsText.text = message;
    }

    void Update()
    {
        // Debug.Log("In Update");
        // Debug.Log("Is Paused:" + isPaused + "inputReceived+ " + inputReceived);

        // Check if the game is paused and input hasn't been received yet
        if (isPaused && !inputReceived)
        {
            // Check for input based on current stage
            switch (currentStage)
            {
                // For these stages, continue game on any arrow key press
                case TutorialStage.Movement:
                case TutorialStage.CollectDiamond:
                case TutorialStage.CollectDiamond2:
                case TutorialStage.GhostAbility2:
                case TutorialStage.Finish:
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
                        Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) ||
                        Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                        Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        inputReceived = true;
                        ContinueGame();
                    }
                    break;

                // For GhostAbility stage, continue game on T key press
                case TutorialStage.GhostAbility:
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        inputReceived = true;
                        ContinueGame();
                    }
                    break;
            }
        }
        else
        {
            // Additional game logic if needed
        }
        // Debug.Log(currentStage == TutorialStage.CollectDiamond && scoreObject.text == "1");
        // Check if score becomes 1 for CollectDiamond stage
        if (currentStage == TutorialStage.CollectDiamond && scoreObject.text == "1")
        {
            currentStage = TutorialStage.GhostAbility;
            StartCoroutine(ShowInstructionsAfterDelay("Press T to use your ghost ability to escape", 2f));
        }

        // Check if score becomes 2 for CollectDiamond2 stage
        if (currentStage == TutorialStage.CollectDiamond2 && scoreObject.text == "2")
        {
            currentStage = TutorialStage.Finish;
            StartCoroutine(ShowInstructionsAfterDelay("Well Done! Now escape through EXIT", 2f));
        }
    }

}
