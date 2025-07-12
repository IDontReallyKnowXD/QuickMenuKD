using UnityEngine;
using System;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/QuickMenuScriptableObject", order = 1)]
public class ItemQuickMenu : ScriptableObject
{
    public int id;
    public int uses;
    public Sprite sprite;
    public int BonusID;
    public int BonusAmount;
    public int Amount;
    public int MaxUses;
    [TextArea]
    public string comment;
}
