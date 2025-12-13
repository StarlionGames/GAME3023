using System.Collections.Generic;
using UnityEngine;

public class RoomData : ScriptableObject
{
    public HashSet<ItemOverworld> ItemsInScene = new HashSet<ItemOverworld>();
}
