using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private Card[] neighbours;
    
    public bool isFree;

    public Vector3[] GetNeighboursPosition()
    {
        List<Vector3> neighboursPosition = new List<Vector3>();

        foreach (var neighbour in neighbours)
        {
            Vector3 neighbourPos = neighbour.transform.position;
            neighboursPosition.Add(neighbourPos);
        }

        return neighboursPosition.ToArray();
    }
}
