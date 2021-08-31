using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetUp : MonoBehaviour
{
    [Header("White")]
    public Camera whiteCam;
    public Material whiteCamMat;

    [Header("Yellow")]
    public Camera yellowCam;
    public Material yellowCamMat;

    // Start is called before the first frame update
    void Start()
    {
        if (whiteCam.targetTexture != null)
        {
            whiteCam.targetTexture.Release();
        }
        whiteCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        whiteCamMat.mainTexture = whiteCam.targetTexture;

        if (yellowCam.targetTexture != null)
        {
            yellowCam.targetTexture.Release();
        }
        yellowCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        yellowCamMat.mainTexture = yellowCam.targetTexture;
    }
}
