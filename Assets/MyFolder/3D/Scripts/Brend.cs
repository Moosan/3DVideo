using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brend : MonoBehaviour {
    public Material mate;
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        src = new RenderTexture(1920,1080,-1);
        Graphics.Blit(src, dest,mate);
    }
}
