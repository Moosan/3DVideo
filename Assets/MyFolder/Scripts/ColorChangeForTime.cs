using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangeForTime : MonoBehaviour
{
    [SerializeField]
    private float duration;
    [SerializeField]
    private Color[] colors;
    private Color color {
        get {
            return GetComponent<Image>().color;
        }
        set {
            GetComponent<Image>().color = value;
        }
    }
    private void Start()
    {
        color = GetComponent<Image>().color;
        StartCoroutine(ChangeColorCorutin());
    }
    IEnumerator ChangeColorCorutin()
    {
        while (true)
        {
            foreach (var color in colors) {
                yield return StartCoroutine(ChangeColor(color, duration));
            }
        }
    }

    IEnumerator ChangeColor(Color toColor, float duration)
    {
        Color fromColor = color;
        float startTime = Time.time;
        float endTime = Time.time + duration;
        float marginR = toColor.r - fromColor.r;
        float marginG = toColor.g - fromColor.g;
        float marginB = toColor.b - fromColor.b;
        float marginA = toColor.a - fromColor.a;
        while (Time.time < endTime)
        {
            fromColor.r = fromColor.r + (Time.deltaTime / duration) * marginR;
            fromColor.g = fromColor.g + (Time.deltaTime / duration) * marginG;
            fromColor.b = fromColor.b + (Time.deltaTime / duration) * marginB;
            fromColor.a = fromColor.a + (Time.deltaTime / duration) * marginA;
            color = fromColor;
            yield return 0;
        }
        color = toColor;
        yield break;
    }
}
