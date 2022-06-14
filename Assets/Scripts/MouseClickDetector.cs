using System;
using UnityEngine;

public class MouseClickDetector : MonoBehaviour
{
    public event Action OnMouseClickedEvent;
    
    private void OnMouseDown()
    {
        OnMouseClickedEvent?.Invoke();
    }
}
