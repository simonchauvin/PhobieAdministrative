using UnityEngine;
using System.Collections;

public class LastBehaviour : NavigationBehaviour {

    public override void Start()
    {
        base.Start();
    }


    public override void Update()
    {
        base.Update();

    }

    public override void activate()
    {
        base.activate();

        KeyAudioManager keyAudioManager = FindObjectOfType<KeyAudioManager>();
        InterfaceManager interfaceManager = FindObjectOfType<InterfaceManager>();
        keyAudioManager.audioSource.Stop();
        interfaceManager.GoToNormalInterface();
        NavigationManager.instance.reset();
        PlayerProfile.instance.reset();
    }
}
