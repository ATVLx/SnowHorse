using UnityEngine;
using System.Collections;

public class TestCommand : MonoBehaviour 
{

	// Use this for initialization
	void Awake() 
	{
		Console.AddCommand(new ConsoleCommand("test", "a test command", CmdParameterType.String, gameObject, "OnTest"));
	}
	
	void OnTest(string param)
	{
		Console.Log("OnTest(" + param + ")");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
