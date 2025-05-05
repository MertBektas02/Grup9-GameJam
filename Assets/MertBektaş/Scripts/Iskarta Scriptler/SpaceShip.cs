using UnityEngine;
using System.Collections.Generic;


public class SpaceShip : MonoBehaviour
{
    [Header("-----SpaceShip objesi-----")]
    //[SerializeField] private GameObject spaceShip;
    //[Header("SpaceShip'in gideceği yolların pozisyonları")]
    [SerializeField] private GameObject[] spaceShipPos;
    private List<GameObject> spaceShipPosList = new List<GameObject>();
    [SerializeField]private float shipMoveSpeed=2;
    private GameObject currentTarget;//En yakındaki pozisyonu bu objeye ata

    void Start()
    {
        spaceShipPosList.AddRange(spaceShipPos);
    }

    void Update()
    {
        if (currentTarget == null&& spaceShipPosList.Count>0)
        {
            currentTarget = GetClosestTarget();
        }

        if (currentTarget != null)
        {
            MoveToTarget();
        }
    }

    GameObject GetClosestTarget()
    {
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        foreach (GameObject target in spaceShipPosList)
        {
            float distance = Vector3.Distance(currentPos, target.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = target;
            }
        }

        return closest;
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, shipMoveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget.transform.position) < 0.1f)
        {
            spaceShipPosList.Remove(currentTarget); // Listeden çıkar
            currentTarget = null;
        }
    }

}
