using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEntrance : MonoBehaviour
{
    public ID globalID; // guid
    public Destination destination;
    public Vector3 position => transform.position;
    public Quaternion rotation => transform.rotation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out Player p)) { return; }

        GameManager.instance.mapManager.TeleportPlayer(destination);
    }
}

[System.Serializable]
public struct Destination
{
    public SceneDirectory sceneLocation;
    public string entranceID;

    public Destination(SceneDirectory scene, string ID)
    {
        this.sceneLocation = scene;
        this.entranceID = ID;
    }
}
