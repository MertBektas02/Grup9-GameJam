using UnityEngine;
using UnityEngine.UI;

public class DestroyShipButtonController : MonoBehaviour
{
    public Button destroyButton;
    private GameObject assignedShipToDeactivate;

    void Start()
    {
        destroyButton.onClick.AddListener(DeactivateShip);
    }

    void DeactivateShip()
    {
        if (assignedShipToDeactivate != null)
        {
            assignedShipToDeactivate.SetActive(false);
            assignedShipToDeactivate = null;            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ship"))
        {
            Debug.Log("Ship entered trigger area");
            assignedShipToDeactivate = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Ship exited trigger area");
        if (other.gameObject == assignedShipToDeactivate)
        {
            assignedShipToDeactivate = null;
        }
    }




    //DESTROYLAMAK YERİNE DEAKTİVE ETMEYE KARAR VERDİM
    // public Button destroyButton;
    // private GameObject assignedShipToDestroy;

    // void Start()
    // {
    //     destroyButton.onClick.AddListener(DestroyShip);
    // }

    // void DestroyShip()
    // {
    //     if (assignedShipToDestroy!=null)
    //     {
    //     Destroy(assignedShipToDestroy);
    //     assignedShipToDestroy=null;            
    //     }
    // }
    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Ship"))
    //     {
    //         Debug.Log("ship entered");
    //         assignedShipToDestroy=other.gameObject;
    //     }
    // }
    // void OnTriggerExit(Collider other)
    // {
    //     Debug.Log("ship exit");
    //     if (other.gameObject==assignedShipToDestroy)
    //     {
            
    //         assignedShipToDestroy=null;
    //     }
    // }













    // void DestroyShip()
    // {


    // }

    // void ClickButton()
    // {
    //     destroyButton.onClick.AddListener(DestroyShip);
    // }

    // public void OnTriggerEnter(Collider ship)
    // {
    //     if (ship.CompareTag("Ship"))
    //     {

    //     }
    // }


}
