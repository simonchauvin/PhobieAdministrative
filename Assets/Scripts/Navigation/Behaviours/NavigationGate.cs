using UnityEngine;
using System.Collections;

/// <summary>
/// Always come in pair ! Select same condition in enum and invert matchCondition! 
/// </summary>
public class NavigationGate : NavigationBehaviour {

    public PlayerProfile.playerInfoType conditionToCheck;

    public int resultToMatch = 0;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        if (!isActive)
            return;

        if(PlayerProfile.instance.checkProfileValue(conditionToCheck, resultToMatch))
        {
            navigateToTarget();
        }
    }


}
