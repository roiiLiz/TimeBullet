using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEXP : MonoBehaviour
{
    [SerializeField]
    private int levelMultiplier = 5;

    private int currentLevel;
    private int currentExp;

    public static event Action levelUp;
    public static event Action<int, int, int> expInfo; // current exp, exp to next level, current level

    private int expRequirement(int level)
    {
        return level * levelMultiplier;
    }

    private void OnEnable() { EnemyScript.giveExp += AddExp; }
    private void OnDisable() { EnemyScript.giveExp -= AddExp; }

    private void Start()
    {
        currentLevel = 1;
        currentExp = 0;

        expInfo?.Invoke(currentExp, expRequirement(currentLevel), currentLevel);
    }

    private void AddExp(int expToAdd) 
    {
        currentExp += expToAdd;
        if (currentExp >= expRequirement(currentLevel))
        {
            currentExp = currentExp - expRequirement(currentLevel);
            currentLevel++;
            
            Debug.Log($"Leveled Up! Current Level: {currentLevel}");
            levelUp?.Invoke();
        }

        expInfo?.Invoke(currentExp, expRequirement(currentLevel), currentLevel);
    }

    [ContextMenu("Force Level Up")]
    private void ForceLevelUp()
    {
        AddExp(expRequirement(currentLevel) - currentExp);
    }
}
