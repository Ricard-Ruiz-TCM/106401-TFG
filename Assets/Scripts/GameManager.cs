using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour {

    // Yarn script variable storage
    public InMemoryVariableStorage _storage;

    public bool GetValue<T>(string name, out T result) {
        return _storage.TryGetValue<T>(name, out result);
    }

}
