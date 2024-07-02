using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [Header("Target")]
    [SerializeField]
    private Transform TargetTransform;

    [Header("Follow Properties")]
    [SerializeField]
    private float FollowSpeed = 2f;

    private void Update()
    {
        Vector3 newPosition = (TargetTransform.position - transform.position) * FollowSpeed * Time.deltaTime;
        newPosition.x += transform.position.x;
        newPosition.y += transform.position.y;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}
