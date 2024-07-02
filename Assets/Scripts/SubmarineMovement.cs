using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SubmarineMovement : MonoBehaviour
{
    [SerializeField]
    private float GravityOutOfWater = 9.81f;

    private SubmarineInputActions InputActions;
    private InputAction Move;
    private Rigidbody2D SubmarineRigidbody;
    private SubmarineStats Stats;
    private bool InWater = true;

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
        if (InWater)
        {
            Vector2 force = Move.ReadValue<Vector2>() * Stats.Speed * Time.deltaTime;
            SubmarineRigidbody.AddForce(force);
        }
        else
        {
            Vector2 force = Move.ReadValue<Vector2>() * Stats.Speed * Time.deltaTime;
            force.y = 0f;
            SubmarineRigidbody.AddForce(force);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Air")
        {
            Debug.Log("Out water");
            GoOutWater();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Air")
        {
            Debug.Log("In water");
            GoInWater();
        }
    }

    private void GoOutWater()
    {
        InWater = false;
        SubmarineRigidbody.gravityScale = GravityOutOfWater;
    }

    private void GoInWater()
    {
        InWater = true;
        SubmarineRigidbody.gravityScale = 0f;
    }
}
