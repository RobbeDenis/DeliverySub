using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    private BoxCollider2D BoxCollider;

    private void Awake()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    public void ClampCameraPosition(Camera camera, ref Vector3 position)
    {
        float xMin = transform.position.x - (BoxCollider.size.x / 2f) + camera.orthographicSize;
        float xMax = transform.position.x + (BoxCollider.size.x / 2f) - camera.orthographicSize;
        position.x = Mathf.Clamp(position.x, xMin, xMax);

        float yMin = transform.position.y - (BoxCollider.size.y / 2f) + camera.orthographicSize;
        float yMax = transform.position.y + (BoxCollider.size.y / 2f) - camera.orthographicSize;
        position.y = Mathf.Clamp(position.y, yMin, yMax);
    }
}
