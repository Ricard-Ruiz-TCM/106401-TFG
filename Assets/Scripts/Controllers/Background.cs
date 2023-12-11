using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour {

    [SerializeField]
    private string _fileName;

    [SerializeField]
    private Image _background;

    // Unity Update
    private void Update() {
        string str = _fileName;
        GameManager.instance.GetValue<string>("$background", out str);
        if ((str != "") && (str != _fileName)) {
            _fileName = str;
            _background.sprite = Resources.Load<Sprite>("background/" + _fileName);
        }
    }


}
