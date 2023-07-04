using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
//This script is made by Bobsi Unity for Youtube
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public GameObject prefab;
}
 