using UnityEngine;
using System.Collections;

public class SingleInputBehaviour : NavigationBehaviour
{
    public char characterToEnter;

	
	public override void Start ()
    {
        base.Start();

	}


    public override void Update()
    {
        base.Update();

	}

    public override void receiveInput(string input)
    {
        if (input.Equals(characterToEnter.ToString()))
        {
            navigateToTarget();
        }
    }
}
