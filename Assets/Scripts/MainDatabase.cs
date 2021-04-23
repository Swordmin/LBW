using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDatabase : MonoBehaviour
{

    public GUIStyle style;
    [SerializeField] private List<Item> _items = new List<Item>();
    public static MainDatabase _mainDatabse;

    private void Start()
    {
        if (!_mainDatabse)
            _mainDatabse = this;
    }

    public void AddItem(Item item) 
    {
        _items.Add(item);
    }

    public void AddCount(string name, int count) 
    {
        foreach(Item item in _items) 
        {
            if(item.GetName() == name) 
            {
                item.Add(count);
            }
        }
    }

    public void RemoveCount(string name, int count)
    {
        foreach (Item item in _items)
        {
            if (item.GetName() == name)
            {
                item.Remove(count);
            }
        }
    }

    public bool Craft(string name) 
    {
        Item craftItem = null;
        Item[] ingredients = null;
        bool[] isIngredients = null;
        int[] minusCount = null;
        foreach(Item item in _items) 
        {
            if(item.GetName() == name) 
            {
                craftItem = item;
                ingredients = item.GetItemsCraft();
                isIngredients = new bool[ingredients.Length];
                minusCount = new int[ingredients.Length];
            }
        }

        for(int i = 0; i < ingredients.Length; i++) 
        {
            for(int j = 0; j < _items.Count; j++) 
            {
                if(_items[j].GetName() == ingredients[i].GetName()) 
                {
                    if(_items[j].GetCount() >= ingredients[i].GetCount())
                    {           
                        RemoveCount(_items[j].GetName(), ingredients[i].GetCount());
                        isIngredients[i] = true;
                        break;
                        
                    }
                }
            }
        }

        for(int k = 0; k < isIngredients.Length; k++) 
        {
            if(!isIngredients[k])
            {
                Debug.Log("Крафт не прошел");
                return false;
            }

        }
        foreach(Item item in _items) 
        {
            if(item == craftItem) 
            {
                AddCount(item.GetName(), 1);
            }
        }
        Debug.Log("Крафт прошел");
        return true;
        
    }

}
