using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetUp : MonoBehaviour
{
    [Header("Cam_B")]
    public Camera cam_B;
    public Material cam_B_Mat;

    [Header("Cam_G")]
    public Camera cam_G;
    public Material cam_G_Mat;

    [Header("Cam_R")]
    public Camera cam_R;
    public Material cam_R_Mat;

    [Header("Cam_W")]
    public Camera cam_W;
    public Material cam_W_Mat;

    [Header("Cam_Y")]
    public Camera cam_Y;
    public Material cam_Y_Mat;

    // Start is called before the first frame update
    void Start()
    {
        if (cam_B.targetTexture != null)
        {
            cam_B.targetTexture.Release();
        }
        cam_B.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cam_B_Mat.mainTexture = cam_B.targetTexture;

        if (cam_G.targetTexture != null)
        {
            cam_G.targetTexture.Release();
        }
        cam_G.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cam_G_Mat.mainTexture = cam_G.targetTexture;

        if (cam_R.targetTexture != null)
        {
            cam_R.targetTexture.Release();
        }
        cam_R.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cam_R_Mat.mainTexture = cam_R.targetTexture;

        if (cam_W.targetTexture != null)
        {
            cam_W.targetTexture.Release();
        }
        cam_W.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cam_W_Mat.mainTexture = cam_W.targetTexture;

        if (cam_Y.targetTexture != null)
        {
            cam_Y.targetTexture.Release();
        }
        cam_Y.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cam_Y_Mat.mainTexture = cam_Y.targetTexture;
    }
}
