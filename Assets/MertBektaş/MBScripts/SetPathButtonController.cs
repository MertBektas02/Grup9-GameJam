using UnityEngine;

public class SetPathButtonController : MonoBehaviour
{
    public PathVisualizer pathVisualizer;
    public SpaceShipMovement spaceShip;

    public void MoveGateOne()
    {
        pathVisualizer.UseGateOnePath();
        spaceShip.StartMovement();
    }
    public void MoveGateTwo()
    {
        pathVisualizer.UseGateTwoPath();
        spaceShip.StartMovement();
    }
    public void MoveGateThree()
    {
        pathVisualizer.UseGateThreePath();
        spaceShip.StartMovement();
    }
    public void CallShipNextToYou()
    {
        pathVisualizer.CallShip();
        spaceShip.StartMovement();
    }
}
