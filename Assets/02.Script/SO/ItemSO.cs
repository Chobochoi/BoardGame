using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int num;
    public Sprite sprite;
    public float percent;
}

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/ItemSO")]
public class ItemSO : ScriptableObject
{
    public Item[] items;
}
