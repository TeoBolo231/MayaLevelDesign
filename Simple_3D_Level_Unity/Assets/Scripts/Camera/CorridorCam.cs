using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorCam : MonoBehaviour
{
    public Transform cam;
    public Transform player;

    public float camDistanceMin = 0.5f;
    public float camDistanceMax = 5f;

    public float camDistance;
    public Vector3 cameraDirection;
    public Vector3 offset;

    public LayerMask layerMask;

    private void Start()
    {
        cameraDirection = cam.transform.localPosition.normalized;
        camDistance = camDistanceMax;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position + offset, 0.5f);
        CameraOcclusion(cam);
    }

    public void CameraOcclusion(Transform cam)
    {
        Vector3 newCamPosition = transform.TransformPoint(cameraDirection * camDistanceMax);

        Debug.DrawLine(transform.position, newCamPosition, Color.green);

        if (Physics.Linecast(transform.position, newCamPosition, out RaycastHit hit, layerMask))
        {
            camDistance = Mathf.Clamp(hit.distance, camDistanceMin, camDistanceMax);
        }

        else
        {
            camDistance = camDistanceMax;
        }

        cam.localPosition = cameraDirection * camDistance;
    }
}
