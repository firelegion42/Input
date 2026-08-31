using UnityEngine;

public class PlayerMove : MonoBehaviour, IMoveable, IDataManager
{
    [SerializeField] private float _movementSpeed;

    private Vector2 _moveInput;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 input)
    {
        _moveInput = input;
    }

    private void Update()
    {
        rb.linearVelocity = new Vector3(_moveInput.x * _movementSpeed, rb.linearVelocity.y, _moveInput.y * _movementSpeed);
    }

    public void LoadData(GameData data)
    {
        _movementSpeed = data.movementSpeed;
    }

    public void SaveData(GameData data)
    {
        data.movementSpeed = _movementSpeed;
    }
}
