using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CRT : MonoBehaviour {
    public Shader crtShader;
  
    public float curvature = 1.0f;

    public float vignetteWidth = 30.0f;

    private Material crtMat;

    void Start() {
        crtMat = new Material(crtShader);
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        crtMat.SetFloat("_Curvature", curvature);
        crtMat.SetFloat("_VignetteWidth", vignetteWidth);
        Graphics.Blit(source, destination, crtMat);
    }


}
