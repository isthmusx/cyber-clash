using UnityEngine;
using UnityEngine.UI;

public class ButtonSpinner : MonoBehaviour
{
    public float rotationSpeed = 360f; // Speed of rotation in degrees per second
    private bool isSpinning = false; // Flag to check if the button is currently spinning
    private float spinTime = 0.8f; // Time for which the button will spin
    private float spinTimer = 0f; // Timer to keep track of the spinning duration

    private Button button; // Reference to the button component
    public GameObject panel; // Reference to the panel GameObject
    public GameObject buttonGameObject; // Reference to the button GameObject

    void Start()
    {
        // Get the button component attached to this GameObject
        button = GetComponent<Button>();

        // Add the OnButtonClick method as a listener to the button's onClick event
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }

        // Ensure the panel is initially hidden
        if (panel != null)
        {
            panel.SetActive(false);
        }

        // Initialize buttonGameObject if not set in Inspector
        if (buttonGameObject == null)
        {
            buttonGameObject = gameObject;
        }
    }

    void Update()
    {
        // Check if the button is currently spinning
        if (isSpinning)
        {
            // Rotate the button around the Z-axis
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

            // Increment the spin timer by the time elapsed since the last frame
            spinTimer += Time.deltaTime;

            // Check if the spin time has been reached
            if (spinTimer >= spinTime)
            {
                // Stop spinning and reset the timer
                isSpinning = false;
                spinTimer = 0f;

                // Show the panel
                if (panel != null)
                {
                    panel.SetActive(true);
                }

                // Hide the button itself
                if (buttonGameObject != null)
                {
                    buttonGameObject.SetActive(false);
                }
            }
        }
    }

    // Method to be called when the button is clicked
    void OnButtonClick()
    {
        // Start spinning and reset the spin timer
        isSpinning = true;
        spinTimer = 0f;

        // Hide the panel if it was previously shown
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}
