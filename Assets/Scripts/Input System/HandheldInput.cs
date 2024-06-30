using System;
using UnityEngine;

public class HandheldInput : MonoBehaviour, IInputController
{
    public event Action<Vector3> Move;
    public event Action<bool> Shoot;
    
    public void CheckInput()
    {
        Debug.Log("HandheldInput");
    }
}
