using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Items/Create New Item")]
public class Item : ScriptableObject 
{
   public int id;
   public String itemName;
   public int value;
   public Sprite icon;
}
