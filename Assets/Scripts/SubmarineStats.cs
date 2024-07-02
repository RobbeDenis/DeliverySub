using UnityEngine;

public class SubmarineStats : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField]
    private float BaseSpeed = 100f;
    [SerializeField]
    private int BaseDepth = 250;
    [SerializeField]
    private float BaseDrag = 0.5f;
    [SerializeField]
    private float BaseMass = 5f;

    public float Speed
    {
        get{ return BaseSpeed; }
    }

    public int Depth
    {
        get{ return BaseDepth; }
    }

    public float Drag
    {
        get{ return BaseDrag; }
    }

    public float Mass
    {
        get { return BaseMass; }
    }

    private Rigidbody2D SubmarineRigidBody;

    private void Awake()
    {
        SubmarineRigidBody = GetComponent<Rigidbody2D>();

        UpdateStats();
    }

    public void UpdateStats()
    {
        SubmarineRigidBody.drag = Drag;
        SubmarineRigidBody.mass = Mass;
    }
}
