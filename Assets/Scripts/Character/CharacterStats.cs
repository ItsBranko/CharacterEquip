using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStats : MonoBehaviour
{

    public UnityEvent<int> IntelligenceChange;
    [SerializeField] private int _intelligence;
    private Item item;


    private void Awake()
    {
        GameObject itemGameObject = GameObject.FindGameObjectWithTag("Item"); 
        if (itemGameObject != null)
        {
            item = itemGameObject.GetComponent<Item>();
        }
    }

    public int GetIntelligence()
    {
        return _intelligence;
    }
    public void SetIntelligence(int value)
    {
        _intelligence = value;
        IntelligenceChange.Invoke(value);
    }

    public UnityEvent<int> StrengthChange;
    [SerializeField] private int _strength;
    public int Strength
    {
        get => _strength;
        set
        {
            _strength = value;
            StrengthChange.Invoke(value);
        }
    }

    public void LevelUp()
    {
        if (item.level <= item.maxLevel)
        {
            Strength += 5;
            SetIntelligence(GetIntelligence() + 3);
            item.level++;
        }
        else
        {
            Debug.Log("Max Level Achived!!!");
        }
    }
}
