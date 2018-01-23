using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToneChange : MonoBehaviour {
    public Material tone;
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, tone);
    }
}
