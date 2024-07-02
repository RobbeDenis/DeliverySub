using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [Header("Target & Bounds")]
    [SerializeField]
    private Transform TargetTransform;
    [SerializeField]
    private CameraBounds Bounds;

    [Header("Follow Properties")]
    [SerializeField]
    private float FollowSpeed = 2f;

    private Camera Camera;

    private void Awake()
    {
        Camera = GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 newPosition = (TargetTransform.position - transform.position) * FollowSpeed * Time.deltaTime;
        newPosition.x += transform.position.x;
        newPosition.y += transform.position.y;
        newPosition.z = transform.position.z;
        Bounds.ClampCameraPosition(Camera, ref newPosition);
        transform.position = newPosition;
    }
}
