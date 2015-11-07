using UnityEngine;
using System.Collections;

public class PlayerProfile : MonoBehaviour
{
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
}
