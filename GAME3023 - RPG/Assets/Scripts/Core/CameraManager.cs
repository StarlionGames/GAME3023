using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    CinemachineCamera cinemachine => GetComponent<CinemachineCamera>();

    private void Awake()
    {
        cinemachine.Follow = Player.Instance.gameObject.transform;
        cinemachine.LookAt = Player.Instance.gameObject.transform;
    }
}
