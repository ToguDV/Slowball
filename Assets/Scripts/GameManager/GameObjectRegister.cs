using UnityEngine;

public class GameObjectRegister : MonoBehaviour
{
    public string name;
    void Start()
    {
        GameObjectManager.Instance.GameObjectDictionary.Add(name, gameObject);
    }
}
