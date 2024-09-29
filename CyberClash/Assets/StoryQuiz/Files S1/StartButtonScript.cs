using UnityEngine;
using UnityEngine.UI;

public class StartPanelButton : MonoBehaviour
{
    public PanelRandomizer panelRandomizer;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StartPanelRandomizer);
    }

    private void StartPanelRandomizer()
    {
        if (panelRandomizer != null)
        {
            panelRandomizer.RandomizeAndShowPanel();
        }
        else
        {
            Debug.LogError("PanelRandomizer reference is not set.");
        }
    }
}
