using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    CinemachineCamera cinemachine => GetComponent<CinemachineCamera>();

    private void Awake()
    {
        if (Player.Instance == null) { return; }    
        cinemachine.Follow = Player.Instance.gameObject.transform;
        cinemachine.LookAt = Player.Instance.gameObject.transform;
    }
}
