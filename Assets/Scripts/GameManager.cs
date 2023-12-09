using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour {

    // GameManager singleton instance
    private static GameManager _instance;
    public static GameManager instance {
        get {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();

            return _instance;
        }

    }

    // Yarn script variable storage
    public InMemoryVariableStorage _storage;

    // Unity Awake
    private void Awake() {
        _instance = this;
    }

    public bool GetValue<T>(string name, out T result) {
        return _storage.TryGetValue<T>(name, out result);
    }

}
