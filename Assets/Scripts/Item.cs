using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType 
{
    Resources = 0,
    Weapon = 1,
    Armor = 2,

}

[System.Serializable]
public class Item 
{
    [SerializeField] private string _name;
    [SerializeField] private ItemType _type;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _count;
    [SerializeField] private Item[] _craft;

    public string GetName() => _name;
    public void Add(int count) 
    {
        if (count > 0)
            _count += count;
    }
    public void Remove(int count)
    {
        if (count > 0 && _count > 0)
            _count -= count;
    }

    public Item[] GetItemsCraft() => _craft;
    public int GetCount() => _count;
    


}
