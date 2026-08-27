using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private PlayerJump _jump;
    [SerializeField] private PlayerMove _movement;
    [SerializeField] private PlayerAttack _attack;

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _jump.Jump();
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        _movement.Move(context.ReadValue<Vector2>());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _attack.Shoot();

        }
    }
}
