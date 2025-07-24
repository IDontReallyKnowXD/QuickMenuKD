using UnityEngine;
using System;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/QuickMenuScriptableObject", order = 1)]
public class ItemQuickMenu : ScriptableObject
{
    public int Id;
    public int Uses;
    public Sprite sprite;
    public int BonusID;
    public int BonusAmount;
    public int Amount;
    public int MaxUses;
    public bool CanBeErased;
    [TextArea]
    public string comment;
}
