using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public static GameObjectManager Instance { get; private set; }

    public Dictionary<string, GameObject> GameObjectDictionary { get; private set; } = new Dictionary<string, GameObject>();

}
