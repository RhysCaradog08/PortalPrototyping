using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    private void Awake()
    {
        playerCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        transform.rotation = playerCamera.rotation;
    }
}
