using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MultipleInputBehaviour : NavigationBehaviour
{
    public PlayerProfile.playerInfoType playerInfoType;

    public string charactersToEnter;

    private List<char> charactersEntered;

    public override void Start()
    {
        base.Start();

        charactersEntered = new List<char>();
    }


    public override void Update()
    {
        base.Update();

        //if (playerInfoType != PlayerProfile.playerInfoType.none)
        //    charactersToEnter == 
    }

    public override void activate()
    {
        base.activate();

        charactersEntered = new List<char>();
    }

    public override void receiveInput(string input)
    {
        charactersEntered.Add(char.Parse(input));
        if (charactersEntered.Count >= charactersToEnter.Length)
        {
            bool correctInput = true;
            for (int i = 0; i < charactersToEnter.Length; i++)
            {
                if (!charactersEntered[charactersEntered.Count - charactersToEnter.Length + i].Equals(charactersToEnter[i]))
                {
                    correctInput = false;
                }
            }
            if (correctInput)
            {
                navigateToTarget();
            }
        }
    }
}
