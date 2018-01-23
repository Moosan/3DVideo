using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRenderer : MonoBehaviour {
    public Camera leftCam, rightCam;
    public int camWidth = 1920, camHeight = 1080;
    private Texture2D leftTexture, rightTexture, mainTexture;
    private int count = 0;

    void Start()
    {
        mainTexture = new Texture2D(camWidth, camHeight, TextureFormat.ARGB32, false);

        var leftTex = leftCam.targetTexture;
        leftTexture = new Texture2D(leftTex.width, leftTex.height, TextureFormat.ARGB32, false);

        var rightTex = rightCam.targetTexture;
        rightTexture = new Texture2D(rightTex.width, rightTex.height, TextureFormat.ARGB32, false);
    }

    void Update()
    {
        // RenderTextureからTexture2Dに変換します
        var leftTex = leftCam.targetTexture;
        RenderTexture.active = leftCam.targetTexture;
        leftTexture.ReadPixels(new Rect(0, 0, leftTex.width, leftTex.height), 0, 0);
        leftTexture.Apply();

        var rightTex = rightCam.targetTexture;
        RenderTexture.active = rightCam.targetTexture;
        rightTexture.ReadPixels(new Rect(0, 0, rightTex.width, rightTex.height), 0, 0);
        rightTexture.Apply();

        // 偶数回目にmainTextureのy行目に左目の画像を入れ，y+1行目に右目の画像を入れます
        for (int y = 0; y < mainTexture.height; y++)
        {
            if (y % 2 == 0)
            {
                for (int x = 0; x < mainTexture.width; x++)
                {
                    if (count < rightTexture.height)
                    {
                        mainTexture.SetPixel(x, y, leftTexture.GetPixel(x, count));
                        mainTexture.SetPixel(x, y + 1, rightTexture.GetPixel(x, count));
                    }
                }
                //ここでfor文との行ずれを調整するために別に用意した変数の値を1ずつ加算します
                count = count + 1;
            }
        }
        mainTexture.Apply();

        count = 0;
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(mainTexture, dest);
    }
}
