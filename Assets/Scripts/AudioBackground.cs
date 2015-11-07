using UnityEngine;
using System.Collections;

public class AudioBackground : MonoBehaviour
{
    private static AudioBackground _instance;

    public enum Type { none, bg1, bg2, bg3, wait1, wait2, wait3 }
    
    public AudioClip bg1Regular;
    public AudioClip bg1Premium;
    public AudioClip bg2Regular;
    public AudioClip bg2Premium;
    public AudioClip bg3Regular;
    public AudioClip bg3Premium;
    public AudioClip wait1Regular;
    public AudioClip wait1Premium;
    public AudioClip wait2Regular;
    public AudioClip wait2Premium;
    public AudioClip wait3Regular;
    public AudioClip wait3Premium;

    public static AudioBackground instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("Player").GetComponent<AudioBackground>();
            }
            return _instance;
        }
    }

	void Start ()
    {
	
	}
	
	
	void Update ()
    {
	
	}

    public AudioClip retrieveAudioClip (Type type)
    {
        AudioClip clip = null;
        
        if (PlayerProfile.instance.isPremium == 0)
        {
            switch (type)
            {
                case Type.none:
                    clip = null;
                    break;
                case Type.bg1:
                    clip = bg1Regular;
                    break;
                case Type.bg2:
                    clip = bg2Regular;
                    break;
                case Type.bg3:
                    clip = bg3Regular;
                    break;
                case Type.wait1:
                    clip = wait1Regular;
                    break;
                case Type.wait2:
                    clip = wait2Regular;
                    break;
                case Type.wait3:
                    clip = wait3Regular;
                    break;
            }
        }
        else if (PlayerProfile.instance.isPremium == 1)
        {
            switch (type)
            {
                case Type.none:
                    clip = null;
                    break;
                case Type.bg1:
                    clip = bg1Premium;
                    break;
                case Type.bg2:
                    clip = bg2Premium;
                    break;
                case Type.bg3:
                    clip = bg3Premium;
                    break;
                case Type.wait1:
                    clip = wait1Premium;
                    break;
                case Type.wait2:
                    clip = wait2Premium;
                    break;
                case Type.wait3:
                    clip = wait3Premium;
                    break;
            }
        }
        
        return clip;
    }
}
