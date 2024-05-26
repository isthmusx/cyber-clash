using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
   public int id;
   public string nameItem;
   public int value;
   public Sprite icon;
   public Sprite icon2;
   public ItemType itemType;

   public enum ItemType
   {
      Icon,
      Board
   }
}
