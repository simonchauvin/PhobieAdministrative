using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class WaitingTimeBehaviour : NavigationBehaviour
{
    // PUBLIC
    public bool waitToEndOfStateClips = false;

    public float timeToWait;

    // PRIVATE
    private float timer;


	public override void Start ()
    {
        base.Start();

        timer = 0f;

        //Set duration to en end of state
        if (waitToEndOfStateClips)
            timeToWait = GetComponent<NavigationState>().duration;

        Debug.Log(".." + name + " : " + timeToWait);
	}


    public override void Update()
    {
        base.Update();
#if UNITY_EDITOR
        //Set duration to en end of state
        if (waitToEndOfStateClips)
            timeToWait = GetComponent<NavigationState>().duration;
#else

       

        
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= timeToWait)
            {
                navigateToTarget();
            }
        }

#endif
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
