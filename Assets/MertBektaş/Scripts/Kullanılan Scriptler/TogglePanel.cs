using UnityEngine;

public class TogglePanel : MonoBehaviour
{

    public GameObject panel;

    private bool isPanelActive = false;

    // Bu method, Button üzerinden çağrılabilir
    public void Toggle()
    {
        if (panel != null)
        {
            isPanelActive = !isPanelActive;
            panel.SetActive(isPanelActive);
        }
    }
}