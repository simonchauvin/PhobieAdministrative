using UnityEngine;
using System.Collections;

public class PlayerPrefSetter : NavigationBehaviour
{
    public PlayerProfile.playerInfoType prefToSet;

    public int resultToSet = 0;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        if (!isActive)
            return;

        PlayerProfile.instance.setProfileValue(prefToSet, resultToSet);
        navigateToTarget();
    }
}
