using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Characters : MonoBehaviour {

    private string _otherFileName;

    [SerializeField, Header("Speaker:")]
    private TextMeshProUGUI _speakerFileName;
    [SerializeField]
    private Image _speaker;

    [SerializeField, Header("Others:")]
    private GameObject _others;
    [SerializeField]
    private GameObject _speakerPrefab;

    // Unity Update
    private void Update() {

        // Speaker
        string name = (_speakerFileName != null ? _speakerFileName.text.ToLower() : "");
        if (name.IndexOf('(') != -1) {
            name = name.Substring(0, name.IndexOf(' '));
        }
        if (name != "") {
            _speaker.sprite = Resources.Load<Sprite>("characters/" + name);
        }

        // others activation
        foreach (Transform t in _others.transform) {
            t.gameObject.SetActive(false);
            if (t.name != name) {
                t.gameObject.SetActive(true);
            }
        }

        // Others
        string str = _otherFileName;
        GameManager.instance.GetValue<string>("$speaker_others", out str);
        if ((str != "") && (str != _otherFileName)) {
            foreach (Transform t in _others.transform) {
                GameObject.Destroy(t.gameObject);
            }
            _otherFileName = str;
            Debug.Log(_otherFileName);
            foreach (string s in _otherFileName.Split('|')) {
                GameObject g = GameObject.Instantiate(_speakerPrefab, _others.transform);
                g.GetComponent<Image>().sprite = Resources.Load<Sprite>("characters/" + s);
                g.name = s;
            }
        }

    }
}
