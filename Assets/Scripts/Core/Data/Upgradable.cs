using System;
using UnityEngine;

[Serializable]
public struct Upgradable
{
    [SerializeField] private float baseValue;

    //public float Value => (BaseValue * multiplier) + addedAmount;
    private float value;
    [HideInInspector] public float Value
    {
        get 
        { 
            if (value == 0) return GetValue();
            else return value;
        }
        set 
        { 
            this.value = value; 
        }
	}
    [SerializeField] private float levelMultiplier;
    [SerializeField] private float multiplier;
    private int level;
    private float addedAmount;


    public Upgradable(float baseValue)
    {
        this.baseValue = baseValue;
        multiplier = 1f;
        addedAmount = 0;
        level = 0;
        levelMultiplier = 0.05f;
        value = this.baseValue * multiplier + addedAmount + (this.baseValue * level * levelMultiplier);
	}

    public void ChangeMultiplier(float rate)
    {
        if (rate > 0)
        {
            multiplier = rate;
        }
    }

    public void AddAmount(float value)
    {
        if (value > 0)
        {
            addedAmount += value;
        }
    }

    public void LevelUp()
    {
        level++;
	}

    public void LevelUp(int level)
    {
        this.level = level;
    }

    private float GetValue()
    {
        return baseValue* multiplier +addedAmount + (baseValue * level * levelMultiplier);
    }
}
