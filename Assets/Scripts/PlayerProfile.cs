using UnityEngine;
using System.Collections;

public class PlayerProfile : MonoBehaviour
{

    private static PlayerProfile _instance;
    public static PlayerProfile instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("Player").GetComponent<PlayerProfile>();
            }
            return _instance;
        }
    }


    public int id = 0;
    public int premiumId = 0;
    public int procedureId = 0;
    public int isPremium { get; set; }
    public int marriedSet { get; set; }
    public int deptSet { get; set; }
    public int ageSet { get; set; }
    public int profileSet { get; set; }
    public int cbSet { get; set; }
    public int resetProfile { get; set; }


    public enum playerInfoType
    {
        none,
        id, 
        premiumId,
        procedureId,
        isPremium,
        marriedSet,
        deptSet,
        ageSet,
        profileSet,
        cbSet,
        resetProfile
    }


	void Start ()
    {
        
	}
	
    private void reset ()
    {
        isPremium = 0;
        marriedSet = 0;
        deptSet = 0;
        ageSet = 0;
        profileSet = 0;
        cbSet = 0;
        resetProfile = 0;
    }
	
	void Update ()
    {
	    //if()
	}

    public bool checkProfileValue(playerInfoType typeToCheck, int resultToMatch)
    {
        switch (typeToCheck)
        {
            case playerInfoType.id:
                return (id == resultToMatch);
            case playerInfoType.cbSet:
                return (cbSet == resultToMatch);
            case playerInfoType.isPremium:
                return (isPremium == resultToMatch);
            case playerInfoType.marriedSet:
                return (marriedSet == resultToMatch);
            case playerInfoType.deptSet:
                return (deptSet == resultToMatch);
            case playerInfoType.ageSet:
                return (ageSet == resultToMatch);
            case playerInfoType.profileSet:
                return (cbSet + isPremium + marriedSet + deptSet + ageSet) == 1;
            default:
                return false; 
        }
    }

    public void setProfileValue(playerInfoType typeToSet, int value)
    {
        switch (typeToSet)
        {
            case playerInfoType.id:
                id = value;
                break;
            case playerInfoType.cbSet:
                cbSet = value;
                break;
            case playerInfoType.marriedSet:
                marriedSet = value;
                break;
            case playerInfoType.deptSet:
                deptSet = value;
                break;
            case playerInfoType.ageSet:
                ageSet = value;
                break;
            case playerInfoType.isPremium:
                isPremium = value;
                break;
            case playerInfoType.resetProfile:
                reset();
                break;
            default:
                break;
        }
    }
}
