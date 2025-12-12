using UnityEngine;
using System;
using UnityEditor;

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
        if (PrefabUtility.IsPartOfPrefabAsset(this)) return;
  
        if (string.IsNullOrEmpty(guid)) { guid = Guid.NewGuid().ToString(); }
    }
}
