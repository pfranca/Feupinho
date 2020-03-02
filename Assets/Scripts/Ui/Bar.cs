using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour{
    public Slider slider;
    public void SetMaxValue(float value) {
        slider.maxValue = value;
        slider.value = value;
    }
    public void SetCurValue(float curValue) {
        slider.value = curValue;
    }
}
