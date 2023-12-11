using UnityEngine;
using UnityEngine.UI;

public class Characters : MonoBehaviour {

    // Speaker
    [SerializeField]
    private string _otherFileName;
    [SerializeField]
    private string _speakerFileName;

    [SerializeField, Header("Speaker:")]
    private Image _speaker;

    [SerializeField, Header("Others:")]
    private GameObject _others;
    [SerializeField]
    private GameObject _speakerPrefab;

    // Unity Update
    private void Update() {

        // Speaker
        string str = _speakerFileName;
        GameManager.instance.GetValue<string>("$speaker", out str);
        if ((str != "") && (str != _speakerFileName)) {
            _speakerFileName = str;
            _speaker.sprite = Resources.Load<Sprite>("characters/" + _speakerFileName);
            foreach (Transform t in _others.transform) {
                t.gameObject.SetActive(false);
                if (t.name != _speakerFileName) {
                    t.gameObject.SetActive(true);
                }
            }
        }

        // Others
        str = _otherFileName;
        GameManager.instance.GetValue<string>("$speaker_others", out str);
        if ((str != "") && (str != _otherFileName)) {
            foreach (Transform t in _others.transform) {
                GameObject.Destroy(t.gameObject);
            }
            _otherFileName = str;
            Debug.Log(_otherFileName);
            foreach (string s in _otherFileName.Split('|')) {
                if (s != _speakerFileName) {
                    Debug.Log(s);
                    GameObject g = GameObject.Instantiate(_speakerPrefab, _others.transform);
                    g.GetComponent<Image>().sprite = Resources.Load<Sprite>("characters/" + s);
                    g.name = s;
                }
            }
        }

    }
}
