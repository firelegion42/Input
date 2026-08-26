using UnityEngine;
using UnityEngine.InputSystem;

public class EventPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int _jumpForce;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _movementSpeed;

    private Vector2 _moveInput;
    private bool _isGrounded;
    

  
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && _isGrounded)
        {
            rb.AddForce(new Vector3(0, _jumpForce, 0));
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(transform.position, 1.2f, _groundMask);
        rb.linearVelocity = new Vector3(_moveInput.x*_movementSpeed, rb.linearVelocity.y, _moveInput.y*_movementSpeed);
    }
}
