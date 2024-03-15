using UnityEngine;
using UnityEngine.UI;

public class CardEnlarger : MonoBehaviour
{
    public GameObject enlargedCardPrefab; // Reference to the prefab of the enlarged card
    private GameObject enlargedCardInstance; // Instance of the enlarged card

    void Update()
    {
        // Check if there is any touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            // Check if the touch phase is began
            if (touch.phase == TouchPhase.Began)
            {
                // Cast a ray from the touch position
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Check if the ray hits any collider
                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the hit object is a card
                    if (hit.collider.CompareTag("CardToHand(Clone)"))
                    {
                        // If an enlarged card is already present, destroy it
                        if (enlargedCardInstance != null)
                        {
                            Destroy(enlargedCardInstance);
                        }

                        // Instantiate the enlarged card prefab
                        enlargedCardInstance = Instantiate(enlargedCardPrefab, Vector3.zero, Quaternion.identity);

                        // Set the position of the enlarged card to the center of the screen
                        enlargedCardInstance.transform.position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);

                        // Set the image of the enlarged card to match the pressed card
                        Image enlargedCardImage = enlargedCardInstance.GetComponent<Image>();
                        Image pressedCardImage = hit.collider.GetComponent<Image>();
                        if (enlargedCardImage != null && pressedCardImage != null)
                        {
                            enlargedCardImage.sprite = pressedCardImage.sprite;
                        }
                    }
                }
            }
        }
    }
}
