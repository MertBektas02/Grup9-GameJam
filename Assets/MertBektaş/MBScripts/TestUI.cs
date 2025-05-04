using UnityEngine;

public class TestUI : MonoBehaviour
{
    public PathVisualizer pathVisualizer;
    public SpaceShipMovement spaceShip;

    public void GateOneBtn()
    {
        pathVisualizer.UseGateOnePath();
        spaceShip.StartMovement();
    }

    public void GateTwoBtn()
    {
        pathVisualizer.UseGateTwoPath();
        spaceShip.StartMovement();
    }
}