using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour {

    [SerializeField]
    private string _fileName;
    private string _tmp;

    // Image background
    private Image _background;

    // Unity Awake
    private void Awake() {
        _background = GetComponent<Image>();
    }

    // Unity Update
    private void Update() {
        GameManager.instance.GetValue<string>("$background", out _tmp);
        if ((_tmp != "") && (_tmp != _fileName)) {
            _fileName = _tmp;
            _background.sprite = Resources.Load<Sprite>("background/" + _fileName);
        }
    }


}
