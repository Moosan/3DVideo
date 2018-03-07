using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
public class eyeContoller : MonoBehaviour {

    [SerializeField]
    private Slider kyori, kaku;
    [SerializeField]
    private InputField kyo, kak;
    [SerializeField]
    private GameObject RightCamera;
    [SerializeField]
    private GameObject LeftCamera;

	void Start () {
        kyo.OnValueChangedAsObservable().Subscribe(value =>OnKyoriValueChange(value));
        kak.OnValueChangedAsObservable().Subscribe(value => OnKakuValueChange(value));
        kyo.OnEndEditAsObservable().Subscribe(value => sisaChange(Parse(value)));
        kak.OnEndEditAsObservable().Subscribe(value => kakuChange(Parse(value)));
        kyori.OnValueChangedAsObservable().Subscribe(value => sisaChange(value));
        kaku.OnValueChangedAsObservable().Subscribe(value => kakuChange(value));
    }
    private void sisaChange(string sisa) {
        kyo.text = sisa;
        var a = float.Parse(sisa);
        RightCamera.transform.localPosition = new Vector3(a, 0, 0);
        LeftCamera.transform.localPosition = new Vector3(-1 * a, 0, 0);
    }
    private void sisaChange(float sisa)
    {
        kyo.text = sisa.ToString();
        RightCamera.transform.localPosition = new Vector3(sisa, 0, 0);
        LeftCamera.transform.localPosition = new Vector3(-1 * sisa, 0, 0);
    }

    private void kakuChange(string kaku) {
        kak.text = kaku.ToString();
        var a = float.Parse(kaku);
        RightCamera.transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, -1 * a, 0));
        LeftCamera.transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, a, 0));
        
    }
    private void kakuChange(float kaku)
    {
        kak.text = kaku.ToString();
        RightCamera.transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, -1 * kaku, 0));
        LeftCamera.transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, kaku, 0));

    }
    private float Floor(float value) {
        return (Mathf.Round(1000 * value) / 1000f);
    }
    private float Parse(string value) {
        if (string.IsNullOrEmpty(value))
        {
            return 0f;
        }
        else {
            return float.Parse(value);
        }
    }
    private void OnKyoriValueChange(string value) {
        sisaChange(ValueParse(value));
    }
    private void OnKakuValueChange(string value)
    {
        kakuChange(ValueParse(value));
    }
    private string ValueParse(string value) {
        float a;
        if (string.IsNullOrEmpty(value)) {
            return "0";
        }
        if (float.TryParse(value, out a))
        {
            var array = value.ToCharArray();
            if (array.Length > 5) {
                return Floor(a).ToString();
            }
            return value;
        }
        return "0";
    }
    
}
