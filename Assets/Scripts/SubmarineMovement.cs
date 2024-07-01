using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SubmarineMovement : MonoBehaviour
{
    [SerializeField]
    private float MovementSpeed = 10f;

    private SubmarineInputActions InputActions;
    private InputAction Move;
    private Rigidbody2D SubmarineRigidbody;

    private void Awake()
    {
        InputActions = new SubmarineInputActions();

        SubmarineRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Move = InputActions.Submarine.Move;
        InputActions.Enable();
    }

    private void Update()
    {
        SubmarineRigidbody.AddForce(Move.ReadValue<Vector2>() * MovementSpeed * Time.deltaTime);
    }
}
