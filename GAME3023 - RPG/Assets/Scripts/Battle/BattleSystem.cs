using System;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public BattleTurn CurrentTurn;

    public static Action<BattleTurn> OnTurnBegin;
    public static Action<BattleTurn> OnTurnEnd;
}
