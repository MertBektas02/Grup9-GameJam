using UnityEngine;
using UnityEngine.UI;

public class UIButtonTriggerControl : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject panelObject;         // Açılıp kapanacak panel
    //public GameObject buttonObject;        // Gösterilecek butonun GameObject’i
    //public Button uiButton;                // Buton component’i

    [Header("Panel Position Settings")]
    // public Transform cameraTransform;      // Kameranın Transform'u
    //public Vector3 panelOffset = new Vector3(0, 0, 2); // Kameraya göre panelin offset'i

    private bool isPanelVisible = false;

    void Start()
    {
        panelObject.SetActive(false);
    }

    void Update()
    {
        // RotateButtonToFaceCamera();
        // RotatePanelToFaceCamera();
        //CheckToggleInput();
        // LookAtCamera();
    }

    // Butona P tuşu ile tıklama simülasyonu
    // private void CheckToggleInput()
    // {
    //     if (Input.GetKeyDown(KeyCode.P) && buttonObject.activeSelf && uiButton != null)
    //     {
    //         uiButton.onClick.Invoke();
    //     }
    // }

    // Paneli aç/kapa
    public void TogglePanel()
    {
        if (panelObject != null)
        {
            isPanelVisible = !isPanelVisible;
            panelObject.SetActive(isPanelVisible);
        }
    }

    // Buton kameraya dönük kalsın
    //private void RotateButtonToFaceCamera()
    //{
    //    if (buttonObject != null && buttonObject.activeSelf && cameraTransform != null)
    //    {
    //        buttonObject.transform.LookAt(cameraTransform);
    //        buttonObject.transform.rotation = Quaternion.Euler(0, buttonObject.transform.eulerAngles.y + 180f, 0);
    //    }
    //}

    //panel kameraya baksın
//    private void RotatePanelToFaceCamera()
//{
//    if (panelObject != null && panelObject.activeSelf && cameraTransform != null)
//    {
//        panelObject.transform.LookAt(cameraTransform);
//        panelObject.transform.rotation = Quaternion.Euler(0, panelObject.transform.eulerAngles.y + 180f, 0);
//    }
//}

    // Panelin pozisyonunu kameraya göre güncelle
    //private void LookAtCamera()
    //{
    //    if (panelObject != null && panelObject.activeSelf && cameraTransform != null)
    //    {
    //        Vector3 forwardOffset = cameraTransform.forward * panelOffset.z;
    //        Vector3 rightOffset = cameraTransform.right * panelOffset.x;
    //        Vector3 upOffset = cameraTransform.up * panelOffset.y;

    //        panelObject.transform.position = cameraTransform.position + forwardOffset + rightOffset + upOffset;
    //        panelObject.transform.rotation = Quaternion.LookRotation(panelObject.transform.position - cameraTransform.position);
    //    }
    //}

    // Trigger’a girince butonu göster
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ship"))
        {
            panelObject.SetActive(true);
        }
    }

    // Trigger’dan çıkınca butonu gizle
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ship"))
        {
            panelObject.SetActive(false);
        }
    }
}
