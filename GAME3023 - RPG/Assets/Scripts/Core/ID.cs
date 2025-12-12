using UnityEngine;
using System;

[ExecuteAlways]
public class ID : MonoBehaviour
{
    [SerializeField] string guid = "";
    public string id => guid;

    private void Awake()
    {
        if (string.IsNullOrEmpty(guid)) { guid = Guid.NewGuid().ToString(); }
    }
    private void OnValidate()
    {
        if (string.IsNullOrEmpty(guid)) { guid = Guid.NewGuid().ToString(); }
    }
}
