using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterStatsUI : MonoBehaviour
{
    public TMP_Text IntelligenceLabel;
    public TMP_Text StrengthLabel;
    public CharacterStats Stats;
    
    void Start()
    {
        Stats.IntelligenceChange.AddListener(OnIntelligenceChange);
        OnIntelligenceChange(Stats.GetIntelligence());
        Stats.StrengthChange.AddListener(OnStrengthChange);
        OnStrengthChange(Stats.Strength);
    }

    private void OnStrengthChange(int newStrength)
    {
        StrengthLabel.text = newStrength.ToString();
    }

    private void OnIntelligenceChange(int newIntelligence)
    {
        IntelligenceLabel.text = newIntelligence.ToString();
    }
}
