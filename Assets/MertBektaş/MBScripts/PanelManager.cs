using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    // Paneller (Inspector'dan atanacak)
    [Header("paneller")]
    public GameObject gateOnePanel;
    public GameObject gateTwoPanel;
    public GameObject gateThreePanel;
    public GameObject mainPanel;

    private bool isMainPanelActive = true;


    //açılan seklemeleri kapatmak için butonlar
    [Header("PC/EXE açma kapama tuşları")]
    public Button closeGateOneButton;
    public Button closeGateTwoButton;
    public Button closeGateThreeButton;
    public Button closePCButton;

    // Yeni eklediğim kısım - EY
    [Header("Player Kontrol")]
    public PlayerMovement playerMovement;



    void Start()
    {
       
        if (gateOnePanel != null) gateOnePanel.SetActive(false);
        if (gateTwoPanel != null) gateTwoPanel.SetActive(false);
        if (gateThreePanel != null) gateThreePanel.SetActive(false);
        if(mainPanel!=null) mainPanel.SetActive(false);

        
        AssignButtonEvents();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMainPanel();
        }
    }

    public void ToggleMainPanel()
    {
        if (mainPanel != null)
        {
            isMainPanelActive = !isMainPanelActive;
            mainPanel.SetActive(isMainPanelActive);
            SetPlayerControl(!isMainPanelActive); // Yeni eklediğim kısım - EY
        }
    }


    void AssignButtonEvents()
    {
        // Buton component'lerini bul ve onClick event'lerini ayarla
        Button[] buttons = GetComponentsInChildren<Button>(true);

        foreach (Button button in buttons)
        {
            // Buton'un adına göre hangi panelin açılacağını belirle
            if (button.gameObject.name == "Gate1Button") 
                button.onClick.AddListener(OpenGateOnePanel);
            else if (button.gameObject.name == "Gate2Button")
                button.onClick.AddListener(OpenGateTwoPanel);
            else if (button.gameObject.name == "Gate3Button")
                button.onClick.AddListener(OpenGateThreePanel); //else if'leri hiç sevemiyorum
        }


        //sekme kapatma butonlar8ı gate info panelleri kapatılacak
        if (closeGateOneButton != null)
            closeGateOneButton.onClick.AddListener(() => ClosePanel(gateOnePanel));
        
        if (closeGateTwoButton != null)
            closeGateTwoButton.onClick.AddListener(() => ClosePanel(gateTwoPanel));
        
        if (closeGateThreeButton != null)
            closeGateThreeButton.onClick.AddListener(() => ClosePanel(gateThreePanel));
        if(closePCButton!=null)
            closePCButton.onClick.AddListener(()=>ClosePanel(mainPanel));
    }

    // Her buton için ayrı açma metodu
    public void OpenGateOnePanel()
    {
        if (gateOnePanel != null)
        {
            gateOnePanel.SetActive(true);
            // Diğer panelleri kapatmak isterseniz:
            // if (gateTwoPanel != null) gateTwoPanel.SetActive(false);
            // if (gateThreePanel != null) gateThreePanel.SetActive(false);
        }
    }

    public void OpenGateTwoPanel()
    {
        if (gateTwoPanel != null)
        {
            gateTwoPanel.SetActive(true);
            // İsteğe bağlı: Diğer panelleri kapat
        }
    }

    public void OpenGateThreePanel()
    {
        if (gateThreePanel != null)
        {
            gateThreePanel.SetActive(true);
            // İsteğe bağlı: Diğer panelleri kapat
        }
    }
    public void ClosePanel(GameObject panel)
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    // Yeni eklediğim kısım - EY
    void SetPlayerControl(bool isActive)
    {
        if (playerMovement != null)
            playerMovement.enabled = isActive;

        Cursor.visible = !isActive;
        Cursor.lockState = isActive ? CursorLockMode.Locked : CursorLockMode.None;
    }

}