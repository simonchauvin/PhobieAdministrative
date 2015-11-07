using UnityEngine;
using System.Collections;

public class PlayMessageBehaviour : NavigationBehaviour
{
    public virtual void Start()
    {
        base.Start();
	}

    public virtual void Update()
    {
        base.Update();

        if (isActive)
        {
            if (NavigationManager.instance.audioClipsSrc.time >= Mathf.Floor(NavigationManager.instance.audioClipsSrc.clip.length))
            {
                navigateToTarget();
            }
        }
	}

    public override void activate()
    {
        base.activate();

        
    }

    public virtual void receiveInput(string input)
    {
        
    }

    
}
