using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetUp : MonoBehaviour
{
    [Header("Yellow")]
    public Camera yellowCam;
    public Material yellowCamMat;

    // Start is called before the first frame update
    void Start()
    {
        if(yellowCam.targetTexture != null)
        {
            yellowCam.targetTexture.Release();
        }
        yellowCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        yellowCamMat.mainTexture = yellowCam.targetTexture;
    }
}
