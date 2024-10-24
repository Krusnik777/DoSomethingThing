using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rigidBody;
    [SerializeField] private float m_movementSpeed = 5f;
    [SerializeField] private float m_turnSpeed = 360;
    private Vector3 _input;

    public Vector3 DirectionInput => _input;

    private void Update()
    {
        GetInput();
        Look();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look()
    {
        if (_input != Vector3.zero)
        {
            Vector3 relativePos = (transform.position + _input.ToIsometric()) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, m_turnSpeed * Time.deltaTime);
        }
    }

    private void Move()
    {
        m_rigidBody.MovePosition(transform.position + (transform.forward * _input.magnitude) * m_movementSpeed * Time.fixedDeltaTime);
    }
}
