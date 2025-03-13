using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item Data")]
public class ItemData : ScriptableObject
{
    public int id;
    public string itemName;
    public GameObject itemPrefab;

    public enum Types
    {
        Puzzles,
        Keyes,
        Information
    }
}
