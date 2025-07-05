using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/QMlistScriptableObject", order = 1)]
public class ItemsList : ScriptableObject //might need to change to singular items
{
    public List<Item> items;
}

[Serializable]
public class Item
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
