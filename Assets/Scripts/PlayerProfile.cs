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


    public int id { get; set; }
    public bool male { get; set; }
    public bool female { get; set; }
    public bool single { get; set; }
    public bool married { get; set; }
    public int dept { get; set; }
    public int age { get; set; }
    public int height { get; set; }
    public int weight { get; set; }
	
    public enum playerInfoType
    {
        id, 
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
        id = Random.Range(100000000, 999999999);
	}
	
	
	void Update ()
    {
	    
	}

    public bool checkMatch(playerInfoType typeToMatch)
    {
        switch(typeToMatch)
        {
            case playerInfoType.male:
                return male;
                break;
            case playerInfoType.female:
                return female;
                break;
            case playerInfoType.single:
                return single;
                break;
            case playerInfoType.married:
                return married;
                break;
            default:
                return false;
                break;

        }
    }
}
