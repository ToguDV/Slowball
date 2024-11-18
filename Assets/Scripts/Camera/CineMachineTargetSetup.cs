using UnityEngine;
using Unity.Cinemachine;
public class CineMachineTargetSetup : MonoBehaviour
{
    public string objectName;
    public CinemachineCamera cineMachine;
    private void Awake()
    {
        cineMachine.Follow = GameObject.Find(objectName).transform;
    }
}
