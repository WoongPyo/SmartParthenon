using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour {
    Text testText;
	void Start () {
        testText = GetComponent<Text>();
	}
	void Update () {
        testText.text = string.Format("프레임 수 :{0}", 1/Time.deltaTime);
	}
}
