using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerInputControl : MonoBehaviour
{
    public InputActionReference m_Tap;
    public Action TapAction;

    public void Init()
    {
        m_Tap.action.performed += OnTap;
    }
    private void OnEnable()
    {
        m_Tap.action.Enable();
    }

    private void OnDisable()
    {
        m_Tap.action.Disable();
    }



    private void OnDestroy()
    {
        m_Tap.action.performed -= OnTap;
    }

    private void OnTap(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        TapAction.Invoke();
    }

}
