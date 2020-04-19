using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal 
{
    public GoalType goalType;

    public int requireAmount;
    public int currentAmount;


    public bool isReached()
    {
        return (currentAmount >= requireAmount);
    }
    public void FishCaught()
    {
        if (goalType == GoalType.Fishing && Input.GetButtonDown("Fishing"))
        {
            currentAmount++;          
        }
        
    }

}

public enum GoalType
{
    Fishing
}
