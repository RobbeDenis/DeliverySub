using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SubmarineMovement : MonoBehaviour
{
    private SubmarineInputActions InputActions;
    private InputAction Move;
    private Rigidbody2D SubmarineRigidbody;
    private SubmarineStats Stats;

    private void Awake()
    {
        InputActions = new SubmarineInputActions();

        SubmarineRigidbody = GetComponent<Rigidbody2D>();
        Stats = GetComponent<SubmarineStats>();
    }

    private void OnEnable()
    {
        Move = InputActions.Submarine.Move;
        InputActions.Enable();
    }

    private void Update()
    {
        SubmarineRigidbody.AddForce(Move.ReadValue<Vector2>() * Stats.Speed * Time.deltaTime);
    }
}
