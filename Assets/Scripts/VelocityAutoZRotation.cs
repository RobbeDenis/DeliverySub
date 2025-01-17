using UnityEngine;

public class VelocityAutoZRotation : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D Body;

    private void Update()
    {
        if (Body.velocity == Vector2.zero)
            return;

        float yx = Mathf.Atan(Body.velocity.y / Body.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, yx);
    }
}
