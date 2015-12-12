using UnityEngine;
using System.Collections;

public enum CmdParameterType
{
	None,
	Integer,
	String,
	Float,
	GameObject,
	Vector3,
	Vector2
}

public enum ConsoleMessageType
{
	Log,
	Warning,
	Error,
	Trace,
	Special
}

public class ConsoleCommand
{
	protected string command = "cmd";
	protected string description = "helptext";
	protected GameObject target;
	protected string messageExecuted;
	protected CmdParameterType parameterType = CmdParameterType.Integer;
	
	public string cmd
	{
		get { return command; }
	}
	
	public string helpText
	{
		get { return command + " " + description; }
	}
	
	public ConsoleCommand(string _command, string _description, CmdParameterType _parameterType,
	                      GameObject _target, string _messageExecuted)
	{
		command = _command; description = _description; parameterType = _parameterType;
		target = _target; messageExecuted = _messageExecuted;
	}
	
	public void Execute(string stringParameter)
	{
		float x=0,y=0,z=0;
		string[] vecValues = null;
		
		if (stringParameter == null)
		{
			if (parameterType == CmdParameterType.None)
				_Execute();
			else
				Console.Log(command + " parameter invalid, requires parameter " + parameterType);
			return;
		}
		
		switch(parameterType)
		{
		case CmdParameterType.Integer:
			int resultInt = 0;
			if (int.TryParse(stringParameter, out resultInt))
				_Execute(resultInt);
			else
				Console.Log(command + " parameter invalid, should be integer", ConsoleMessageType.Error);
			break;
		case CmdParameterType.String:
			_Execute(stringParameter);
			break;
		case CmdParameterType.Float:
			float resultFloat = 0;
			if (float.TryParse(stringParameter, out resultFloat))
				_Execute(resultFloat);
			else
				Console.Log(command + " parameter invalid, should be integer", ConsoleMessageType.Error);
			break;
		case CmdParameterType.GameObject:
			GameObject found = GameObject.Find(stringParameter);
			if (found != null)
				_Execute(found);
			else
				Console.Log(command + " parameter invalid, could not find gameobject", ConsoleMessageType.Error);
			
			break;
		case CmdParameterType.Vector3:
			vecValues = stringParameter.Split(',');
			if (vecValues.Length < 3)
				Console.Log(command + " parameter invalid, should be vector3 (example '0,0,0')", ConsoleMessageType.Error);
			else
			{
				x=0; y=0; z=0;
				if (!float.TryParse(vecValues[0], out x) || 
				    !float.TryParse(vecValues[1], out y) ||
				    !float.TryParse(vecValues[2], out z))
				{
					Console.Log(command + " parameter invalid, should be vector3 (example '0,0,0')", ConsoleMessageType.Error);
				}
				else
					_Execute(new Vector3(x,y,z));
			}
			break;
		case CmdParameterType.Vector2:
			vecValues = stringParameter.Split(',');
			if (vecValues.Length < 2)
				Console.Log(command + " parameter invalid, should be vector2 (example '0,0')", ConsoleMessageType.Error);
			else
			{
				x=0; y=0;
				if (!float.TryParse(vecValues[0], out x) || 
				    !float.TryParse(vecValues[1], out y))
				{
					Console.Log(command + " parameter invalid, should be vector2 (example '0,0')", ConsoleMessageType.Error);
				}
				else
					_Execute(new Vector3(x,y));
			}
			break;
		}
	}
	
	protected void _Execute()
	{
		try
		{
			target.SendMessage(messageExecuted);
		}
		catch(System.Exception e)
		{
			Console.Log(e.Message);
		}
	}
	
	protected void _Execute(object parameter)
	{
		try
		{
			target.SendMessage(messageExecuted, parameter);
		}
		catch(System.Exception e)
		{
			Console.Log(e.Message);
		}
	}
}

public class ConsoleMessage
{
	protected ConsoleMessageType msgType = ConsoleMessageType.Log;
	protected string messageText = "";
	protected string hiddenText = "";
	protected bool expanded = false;
	protected System.DateTime timestamp;
	
	public ConsoleMessage(System.DateTime _timestamp, string _msgText, string _hiddenText, ConsoleMessageType _msgType)
	{
		timestamp = _timestamp;
		messageText = _msgText;
		hiddenText = _hiddenText;
		msgType = _msgType;
	}
	
	public void Draw()
	{
		GUIContent content = null;
		Texture2D icon = Console.icons[(int)msgType];
		
		bool wasWordWrap = GUI.skin.label.wordWrap;
		TextAnchor oldText = GUI.skin.box.alignment;
		Color oldColor = GUI.color;
		
		GUI.skin.label.wordWrap = true;
		GUI.skin.box.alignment = TextAnchor.UpperLeft;
		
		
		switch(msgType)
		{
		case ConsoleMessageType.Warning:
			GUI.color = Color.yellow;
			break;
		case ConsoleMessageType.Error:
			GUI.color = Color.red;
			break;
		case ConsoleMessageType.Trace:
			GUI.color = Color.cyan;
			break;
		}
		
		string msg = messageText;
		
		if (expanded)
			msg += "\n\n" + hiddenText;
		
		if (icon != null)
			content = new GUIContent("[" + timestamp.ToString() + "]: " + msg, icon);
		
		if (msgType != ConsoleMessageType.Trace)
			GUILayout.Label(content);
		else
		{
			if (GUILayout.Button(content, GUI.skin.box))
				expanded = !expanded;
		}
		
		GUI.skin.label.wordWrap = wasWordWrap;
		GUI.skin.box.alignment = oldText;
		GUI.color = oldColor;
	}
}

public class Console : MonoBehaviour {
	
	public Texture2D backgroundLogo;
	public Texture2D[] consoleIcons;
	public string startupMsg = "- DigitalWarlords Console, www.digitalwarlords.com -";
	public string toggleKey = "`";
	public bool logDebug = true;
	
	bool visible = false;
	float yPosition = -200;
	
	static public Texture2D[] icons { get { return Instance.consoleIcons; } }
	
	Vector2 scrollbar = Vector2.zero;
	string entryBox = "";
	ArrayList logEntries = new ArrayList();
	ArrayList commands = new ArrayList();
	
	static public bool IsOpen
	{
		get { return Instance.visible; }
	}
	
	static Console instance;
	static public Console Instance
	{
		get 
		{
			if (instance == null)
			{
				Console oldConsole = (MonoBehaviour.FindObjectOfType(typeof(Console)) as Console);
				if (oldConsole)
				{
					instance = oldConsole;
				}
				else
				{
					GameObject consoleHost = new GameObject("ConsoleHost");
					instance = consoleHost.AddComponent<Console>();
				}
			}
			
			return instance;
		}
	}
	
	void Awake()
	{
		if (instance != null && instance != this)
			Destroy(gameObject);
		else
			DontDestroyOnLoad(gameObject);
		
		Log("--- Console Initalized ---");
		Console.AddCommand(new ConsoleCommand("help", "gets help info", 
		                                      CmdParameterType.None, gameObject, 
		                                      "DisplayHelp"));
		
		Console.AddCommand(new ConsoleCommand("sendmessage", "calls a send message on a game object, parameters (gameObject name) (message)", 
		                                      CmdParameterType.String, gameObject, 
		                                      "ForwardSendMessage"));
		
		if (logDebug)
		{
			Application.RegisterLogCallback(OnDebugLog);
			Console.Log("--- Unity Logger Registered ---");
		}
	}
	
	void OnDebugLog(string logString, string stackTrace, LogType type)
	{
		Console.Log(logString, stackTrace, ConsoleMessageType.Trace);
	}
	
	void OnGUI()
	{
		if (Event.current.type == EventType.KeyDown && Event.current.character == toggleKey[0])
		{
			visible = !visible;
			Event.current.Use();
			return;
		}
		
		if (visible)
			yPosition = Mathf.Lerp(yPosition, 0, 8*Time.deltaTime);
		else
			yPosition = Mathf.Lerp(yPosition, -200, 8*Time.deltaTime);
		
		
		if (yPosition == -200)
			return;
		
		Rect wnd = new Rect(0,yPosition,Screen.width, 200);
		
		int oldDepth = GUI.depth;
		GUI.depth = int.MinValue;
		
		GUILayout.BeginArea(wnd, GUI.skin.box);
		ConsoleWindow();
		GUILayout.EndArea();
		
		GUI.depth = oldDepth;

	}
	
	void ConsoleWindow()
	{	
		if (Event.current.type == EventType.KeyDown)
		{
			if (Event.current.keyCode == KeyCode.Return)
			{
				if (GUI.GetNameOfFocusedControl() == "consoleField")
				{
					if (entryBox != "")
						SendCommand();
				}
				else
				{
					GUI.FocusWindow(GetHashCode());
					GUI.FocusControl("consoleField");
				}
				Event.current.Use();
			}
		}
		
		GUI.DrawTexture(new Rect(Screen.width-backgroundLogo.width, 0, 
		                         backgroundLogo.width, backgroundLogo.height), backgroundLogo);
		
		scrollbar = GUILayout.BeginScrollView(scrollbar);
		{
			foreach(ConsoleMessage msg in logEntries)
				msg.Draw();
		}
		GUILayout.EndScrollView();
		GUILayout.FlexibleSpace();
		
		GUI.SetNextControlName("consoleField");
		entryBox = GUILayout.TextField(entryBox);
	}
	
	static public void AddCommand(ConsoleCommand cmd)
	{
		Instance._AddCommand(cmd);
	}
	
	void _AddCommand(ConsoleCommand cmd)
	{
		commands.Add(cmd);
	}
	
	static public void Log(string msg, string details, ConsoleMessageType type)
	{
		Instance._Log(msg, details, type);
	}
	
	static public void Log(string msg, ConsoleMessageType type)
	{
		Instance._Log(msg, "", type);
	}
	
	static public void Log(string msg)
	{
		Instance._Log(msg, "", ConsoleMessageType.Log);
	}
	
	void _Log(string msg, string details, ConsoleMessageType type)
	{
		logEntries.Add(new ConsoleMessage(System.DateTime.Now, msg, details, type));
		scrollbar.y = float.MaxValue;
	}
	
	void SendCommand()
	{
		if (!CatchCommand(entryBox))
			Log(entryBox + " is an invalid command", ConsoleMessageType.Error);
		
		entryBox = "";
	}
	
	void DisplayHelp()
	{
		string helpString = "\n-- Commands --\n";
		foreach(ConsoleCommand consoleCmd in commands)
		{
			helpString += (consoleCmd.cmd) + "\n";
		}
		
		Console.Log(helpString);
	}
	
	void ForwardSendMessage(string input)
	{
		if (!input.Contains("|"))
		{
			Console.Log("invalid input, requires a gameobject name and message, (gameObject) (message)");
			return;
		}
		
		string[] param = input.Split('|');
		GameObject go = GameObject.Find(param[0]);
		if (go == null)
		{
			Console.Log("gameObject not found", ConsoleMessageType.Error);
			return;
		}
		
		Console.Log("Message sent");
		go.SendMessage(param[1], SendMessageOptions.DontRequireReceiver);
	}
	
	bool CatchCommand(string command)
	{
		string cmd = command;
		string parameter = "";
		
		if (command.Contains(" "))
		{
			int spaceIndex = command.IndexOf(' ');
			
			cmd = command.Substring(0, spaceIndex);
			parameter = command.Substring(command.IndexOf(' ')+1, command.Length-spaceIndex-1);
		}

		foreach(ConsoleCommand consoleCmd in commands)
		{
			if (consoleCmd.cmd.ToLower() == cmd.ToLower())
			{
				if (command.Contains(" "))
					consoleCmd.Execute(parameter);
				else
					consoleCmd.Execute(null);
				
				return true;
			}
		}
		
		return false;
	}
}
