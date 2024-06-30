using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class DesktopInput : MonoBehaviour, IInputController
{
    [SerializeField] private float _deeps = 10f;

    public event Action<Vector3> Move;
    public event Action<bool> Shoot;

    public void Update()
    {
        GetMousePosition();
        MouseInput();
    }

    private void GetMousePosition()
    {
        Vector3 screenPosition = Input.mousePosition;
        screenPosition.z = _deeps;
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(screenPosition);

        Move?.Invoke(mousePosition);  
    }
    
    private void MouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot?.Invoke(true);
        }
        else
        {
            Shoot?.Invoke(false);
        }
    }
}
