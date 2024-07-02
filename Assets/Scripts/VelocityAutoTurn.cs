using UnityEngine;

public class VelocityAutoTurn : MonoBehaviour
{
    [SerializeField]
    private float TurnSpeed = 10f;
    [SerializeField]
    private Rigidbody2D Body;

    private float TargetScale = 1f;

    private void Update()
    {
        if(Body.velocity.x <= 0f)
            TargetScale = -1f;
        else
            TargetScale = 1f;

        float newScale = transform.localScale.x + (TargetScale - transform.localScale.x) * Time.deltaTime * TurnSpeed;
        transform.localScale = new Vector3(newScale, transform.localScale.y, transform.localScale.z);
    }
}
