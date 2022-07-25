using InControl;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool TouchPressed => InputManager.ActiveDevice.Action1.WasPressed;
}
