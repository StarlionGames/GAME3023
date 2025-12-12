using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEntrance : MonoBehaviour
{
    public ID globalID;
    public Destination destination;
    public Vector3 position => transform.position;
    public Quaternion rotation => transform.rotation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scene thisScene = SceneManager.GetActiveScene();
        int index = thisScene.buildIndex;
        GameManager.instance.sceneLoader.LoadNextScene((SceneDirectory)index, destination.sceneLocation);
        // TODO: turn the player's location to the destination id's location
    }
}

[System.Serializable]
public struct Destination
{
    public SceneDirectory sceneLocation;
    public string id;

    public Destination(SceneDirectory scene, string ID)
    {
        this.sceneLocation = scene;
        this.id = ID;
    }
}
