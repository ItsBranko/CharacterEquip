using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int level;
    public float intelligenceMultiplier; // 1.1

    public int maxLevel;
    public int maxStrength;
    
    private bool _equipped;

    public CharacterStats Stats;

    public bool IsEquipped => _equipped;

    public void Equip()
    {
        if (IsEquipped) return;
        
        // It is supposed to give a x% bonus on our intelligence
        // e.g. 23 => 33 (Level 5 * 0.1 per Level = 50% Bonus)
        Stats.SetIntelligence((int)(Stats.GetIntelligence() + (level * intelligenceMultiplier * Stats.GetIntelligence())));     //a lot of ()()()() maybe i can fix that a bit later
        
        // + 16 Strength, because Level 5/10 and MaxStrength is 30
        //                  = 51% of 30 = 15
        Stats.Strength += (int)((float)level / maxLevel * maxStrength);
        _equipped = true;
    }

    public void UnEquip()
    {
        if (!IsEquipped) return;
        
        Stats.SetIntelligence((int)(Stats.GetIntelligence() - (level * intelligenceMultiplier * Stats.GetIntelligence())));
        // formula is correct
        Stats.Strength -= (int)((float)level / maxLevel * maxStrength);
        _equipped = false;
    }
}
