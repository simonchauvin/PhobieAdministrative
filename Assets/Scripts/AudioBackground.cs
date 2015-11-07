using UnityEngine;
using System.Collections;

public class AudioBackground : MonoBehaviour
{
    private static AudioBackground _instance;

    public enum Type { none, regular, premium, wait, waitPremium }
    
    public AudioClip regular;
    public AudioClip premium;
    public AudioClip wait;
    public AudioClip waitPremium;

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
        switch(type)
        {
            case Type.none:
                clip = null;
                break;
            case Type.regular:
                clip = regular;
                break;
            case Type.premium:
                clip = premium;
                break;
            case Type.wait:
                clip = wait;
                break;
            case Type.waitPremium:
                clip = waitPremium;
                break;
        }
        return clip;
    }
}
