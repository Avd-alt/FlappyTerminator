using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action Jumping;
    public event Action Shooting;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumping?.Invoke();
        }

        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            Shooting?.Invoke();
        }
    }
}