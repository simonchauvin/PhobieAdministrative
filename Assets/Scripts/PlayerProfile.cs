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
    public int male { get; set; }
    public int female { get; set; }
    public int single { get; set; }
    public int married { get; set; }
    public int dept { get; set; }
    public int age { get; set; }
    public int height { get; set; }
    public int weight { get; set; }
	
    public enum playerInfoType
    {
        none,
        id, 
        premiumId,
        isPremium,
        procedureId,
        male,
        female,
        single,
        married,
        dept,
        age,
        height,
        weight
    }


	void Start ()
    {
        
	}
	
	
	void Update ()
    {
	    
	}

    public bool checkProfileValue(playerInfoType typeToCheck, int resultToMatch)
    {
        switch (typeToCheck)
        {
            case playerInfoType.id:
                return (id == resultToMatch);
            case playerInfoType.male:
                return (male == resultToMatch);
            case playerInfoType.female:
                return (female == resultToMatch);
            case playerInfoType.single:
                return (single == resultToMatch);
            case playerInfoType.married:
                return (married == resultToMatch);
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
            case playerInfoType.male:
                male = value;
                break;
            case playerInfoType.female:
                female = value;
                break;
            case playerInfoType.single:
                single = value;
                break;
            case playerInfoType.married:
                married = value;
                break;
            default:
                break;
        }
    }
}
