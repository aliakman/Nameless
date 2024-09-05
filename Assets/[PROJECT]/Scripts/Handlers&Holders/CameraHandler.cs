using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private Camera _cam;
    private Camera cam { get { return _cam ? _cam : _cam = Camera.main; } }

    private Transform playerTransform;
    private Vector3 cameraOffset;

    private void Start()
    {
        MakeCamReady(transform);
    }

    private void LateUpdate()
    {
        if (playerTransform == null)
            return;

        cam.transform.position = playerTransform.position + cameraOffset;

    }

    public void MakeCamReady(Transform _target)
    {
        cameraOffset = cam.transform.position - _target.position;

        playerTransform = _target;

    }
}
