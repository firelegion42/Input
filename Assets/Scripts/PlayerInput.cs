using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private int _jumpForce;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _gun;
    [SerializeField] private float _bulletSpeed;
   


    private Vector2 _moveInput;
    private bool _isGrounded;
    private GameObject _currentBullet;

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

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _currentBullet = Instantiate(_bullet, _gun.position, Quaternion.identity);


            Rigidbody currentVelocity = _currentBullet.GetComponent<Rigidbody>();
            currentVelocity.linearVelocity = _gun.up * _bulletSpeed;
            Destroy(_currentBullet, 1);

        }
    }
    
    private void Update()
    {
        _isGrounded = Physics.CheckSphere(transform.position, 1.2f, _groundMask);
        rb.linearVelocity = new Vector3(_moveInput.x * _movementSpeed, rb.linearVelocity.y, _moveInput.y * _movementSpeed);
    }
}
