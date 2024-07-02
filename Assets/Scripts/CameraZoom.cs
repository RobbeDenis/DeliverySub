using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private float StartZoom = 5f;
    [SerializeField]
    private float ZoomSpeed = 0.5f;
    [SerializeField]
    private float MinDistance = 1f;
    [SerializeField]
    private float MaxDistance = 20f;
    [SerializeField]
    private float ClipRange = 0.02f;

    private Camera Camera;
    private SubmarineInputActions InputActions;
    private InputAction Zoom;
    private float TargetZoom;
    private float CurrentZoom;

    private void Awake()
    {
        InputActions = new SubmarineInputActions();
        Camera = GetComponent<Camera>();
    }

    private void OnEnable()
    {
        Zoom = InputActions.Submarine.Zoom;
        InputActions.Enable();
    }

    private void Start()
    {
        CurrentZoom = Camera.orthographicSize;
        TargetZoom = StartZoom;
    }

    private void Update()
    {
        if(Zoom.triggered)
        {
            TargetZoom -= Zoom.ReadValue<float>();
            TargetZoom = Mathf.Clamp(TargetZoom, MinDistance, MaxDistance);
        }

        CurrentZoom += (TargetZoom - CurrentZoom) * ZoomSpeed * Time.deltaTime;

        if (Mathf.Abs(TargetZoom - CurrentZoom) < ClipRange)
            CurrentZoom = TargetZoom;

        Camera.orthographicSize = CurrentZoom;
    }
}
