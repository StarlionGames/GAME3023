using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order =1)]
public class Item : ScriptableObject
{
    [SerializeField]
    int _ID;
    public int ItemID
    {
        get { return _ID; }
        set { _ID = value; }
    }

    [SerializeField]
    string _name = "Item";
    public string Name
    {
        get { return _name; }
        set { _name = value; } 
    }

    [TextArea]
    public string description = "default text.";
    public string category = "undefined";
    public Sprite icon;

    public void Use()
    {
        Debug.Log("Used item " + _name);
    }
}
