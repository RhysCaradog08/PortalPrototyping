using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetUp : MonoBehaviour
{
    [Header("Cam_A")]
    public Camera cam_A;
    public Material cam_A_Mat;

    [Header("Cam_B")]
    public Camera cam_B;
    public Material cam_B_Mat;

    // Start is called before the first frame update
    void Start()
    {
        if (cam_A.targetTexture != null)
        {
            cam_A.targetTexture.Release();
        }
        cam_A.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cam_A_Mat.mainTexture = cam_A.targetTexture;

        if (cam_B.targetTexture != null)
        {
            cam_B.targetTexture.Release();
        }
        cam_B.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cam_B_Mat.mainTexture = cam_B.targetTexture;
    }
}
