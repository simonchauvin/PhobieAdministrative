using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NumericEntry : NavigationBehaviour
{
    public int numberCount = 2;

    private List<char> charactersEntered;

    public float timeToEntry;

    public NavigationState alternateTarget;


    // PRIVATE
    private float timer;

    private bool correctEntry = false;

    public override void Start()
    {
        base.Start();

        timer = 0f;

        charactersEntered = new List<char>();
    }


    public override void Update()
    {
        base.Update();

        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= timeToEntry && correctEntry)
            {
                navigateToTarget();
            }
            else if(timer >= timeToEntry)
            {
                parentNavigationState.deactivate();
                alternateTarget.activate();
                NavigationManager.instance.switchState(targetNavigationState);
            }
        }


    }

    public override void activate()
    {
        base.activate();

        charactersEntered = new List<char>();

        timer = 0f;
        correctEntry = false;
    }

    public override void deactivate()
    {
        base.deactivate();

        timer = 0f;
        correctEntry = false;
    }

    public override void receiveInput(string input)
    {
        charactersEntered.Add(char.Parse(input));
        if (charactersEntered.Count == numberCount)
        {
            correctEntry = true;
            for (int i = 0; i < numberCount; i++)
            {
                int j = 0;
                if (!int.TryParse(charactersEntered[i].ToString(), out j))
                {
                    correctEntry = false;
                }
            }

        }
        else
        {
            correctEntry = false;
        }
    }
}
