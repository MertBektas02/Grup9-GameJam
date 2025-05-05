using UnityEngine;

public class SetPathButtonController : MonoBehaviour
{
    public static SetPathButtonController Instance { get; private set; }

    [Header("References")]
    public PathVisualizer pathVisualizer;
    private SpaceShipMovement currentSpaceShip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentSpaceShip(SpaceShipMovement ship)
    {
        currentSpaceShip = ship;
        Debug.Log("Yeni gemi atandı: " + ship.name);
    }

    private bool CheckReferences()
    {
        if (pathVisualizer == null)
        {
            Debug.LogWarning("PathVisualizer referansı atanmamış!");
            return true;
        }

        if (currentSpaceShip == null)
        {
            currentSpaceShip = FindFirstObjectByType<SpaceShipMovement>();
            
            if (currentSpaceShip == null)
            {
                Debug.LogWarning("Aktif gemi bulunamadı!");
                return true;
            }
            Debug.Log("Sahnedeki gemi otomatik olarak bulundu: " + currentSpaceShip.name);
        }

        return false;
    }

    public void MoveGateOne()
    {
        if (CheckReferences()) return;
        pathVisualizer.UseGateOnePath();
        currentSpaceShip.StartMovement();
    }

    public void MoveGateTwo()
    {
        if (CheckReferences()) return;
        pathVisualizer.UseGateTwoPath();
        currentSpaceShip.StartMovement();
    }

    public void MoveGateThree()
    {
        if (CheckReferences()) return;
        pathVisualizer.UseGateThreePath();
        currentSpaceShip.StartMovement();
    }

    public void CallShipNextToYou()
    {
        if (CheckReferences()) return;
        pathVisualizer.CallShip();
        currentSpaceShip.StartMovement();
    }
}