using UnityEngine;
using System.Collections;

public class WaitingTimeBehaviour : NavigationBehaviour
{
    // PUBLIC
    public float timeToWait;

    // PRIVATE
    private float timer;


	public override void Start ()
    {
        base.Start();

        timer = 0f;
	}


    public override void Update()
    {
        base.Update();
        
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= timeToWait)
            {
                navigateToTarget();
            }
        }
	}

    public override void activate ()
    {
        base.activate();

        timer = 0f;
    }

    public override void receiveInput(string input)
    {

    }
}
