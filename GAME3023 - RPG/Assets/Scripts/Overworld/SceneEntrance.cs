using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    public string localID;
    public string globalID => $"{gameObject.scene.name}/{localID}";
    public Vector3 position => transform.position;
    public Quaternion rotation => transform.rotation;
}
