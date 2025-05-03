using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 3f;
    public Camera playerCam;
    public LayerMask interactableLayer;
    private GameObject currentTarget;
    public TextMeshProUGUI interactionText;
    public GameObject computerScreenUI;

    void Update()
    {
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange, interactableLayer))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                currentTarget = hit.collider.gameObject;
                interactionText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Bilgisayarla etkileþime girildi!");
                    computerScreenUI.SetActive(true);
                }

            }
        }
        else
        {
            currentTarget = null;
            interactionText.gameObject.SetActive(false);
        }
    }
}
