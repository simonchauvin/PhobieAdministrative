using UnityEngine;
using System.Collections;

/// <summary>
/// Always come in pair ! Select same condition in enum and invert matchCondition! 
/// </summary>
public class NavigationGate : NavigationBehaviour {

    public PlayerProfile.playerInfoType conditionToMatch;

    public bool matchCondition = false;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        if (!isActive)
            return;

        if(PlayerProfile.instance.checkMatch(conditionToMatch) == matchCondition)
        {
            navigateToTarget();
        }
    }


}
