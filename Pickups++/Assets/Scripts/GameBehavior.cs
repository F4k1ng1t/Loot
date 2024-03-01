using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;

public class GameBehavior : MonoBehaviour, Imanager
{


    public delegate void DebugDelegate(string newText);

    public DebugDelegate debug = Print;
    
    private int _keysCollected = 0;
    private int _currentKeys = 0;
    private int _locksRemaining = 3;
    public string labelText = "Collect all 3 keys to unlock the gate and escape!";
    public int maxKeys = 3;
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    public PlayerBehavior Player;
    private int currentHP;
    public Stack<string> lootStack = new Stack<string>();
    private string _state;
    public string State
    {
        get { return _state; }

        set { _state = value; }
    }
    void Start()
    {
        Initialize(); 
        InventoryList<string> inventoryList = new InventoryList<string>();
        inventoryList.SetItem("Potion");
        Debug.Log(inventoryList.Item);
    }

    public void Initialize()
    {
        _state = "Manager initialized..";
        _state.FancyDebug();
        Debug.Log(_state);
        debug(_state);
        lootStack.Push("Sword of Doom");
        lootStack.Push("HP+");
        lootStack.Push("Golden Key");
        lootStack.Push("Winged Boot");
        lootStack.Push("Mythril Bracers");
        LogWithDelegate(debug);

        GameObject player = GameObject.Find("Player");
        Player.playerJump += HandlePlayerJump;
        
    }
    public void PrintLootReport()
    {
        var currentItem = lootStack.Pop();
        var nextItem = lootStack.Peek();

        Debug.LogFormat("You got a {0}! You've got a good chance of finding a {1} next!", currentItem, nextItem);
        Debug.LogFormat("There are {0} random loot items waiting for you!",lootStack.Count);
    }
    public static void Print(string newText)
    {
        Debug.Log(newText);
    }
    public void LogWithDelegate(DebugDelegate del)
    {
        del("Delegating the debug task");
    }
    public void HandlePlayerJump()
    {
        debug("Player has jumped...");
    }
    public int Keys
    {
        get { return _keysCollected; }

        set 
        { 
            _keysCollected = value;
            
            if (_keysCollected >= maxKeys)
            {
                labelText = "You've found all the keys! Go unlock the gate!";
                
            }
            else
            {
                labelText = "Key found, only " + (maxKeys - _keysCollected) + " more to go.";
            }
        }
        

    }
    public int Locks
    {
        get { return _locksRemaining; }

        set
        {
            _locksRemaining = value;

            if (_locksRemaining == 0)
            {
                
                showWinScreen = true;
                Time.timeScale = 0f;
            }
        }
    }
    public int HP
    {
        get { return currentHP; }

        set
        {
            currentHP = value;
            if (currentHP <= 0)
            {
                labelText = "You died. Try again?";
                showLossScreen = true;
            }
            if (currentHP > 1)
            {
                labelText = "You feel invigorated.";
            }
        }
    }

    public int currentKeys
    {
        get { return _currentKeys; }

        set
        {
            _currentKeys = value;
            if (_currentKeys == 0)
            {
                Player.hasKey = false;
            }
            if(_currentKeys > 0)
            {
                Player.hasKey = true;
            }
        }
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(20,50,150,25), "Keys Collected:" + _keysCollected);

        GUI.Label(new Rect(Screen.width / 2, Screen.height - 50,300,50), labelText);
        if (showLossScreen)
        {
            Cursor.lockState = CursorLockMode.Confined;
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50,200,100),"You died."))
            {
                try
                {
                    Utilities.RestartLevel(-1);
                    debug("Level restarted successfully");
                }
                catch (System.ArgumentException e)
                {
                    Utilities.RestartLevel(0);
                    debug($"Reverting to scene 0: {e.ToString()}");
                }
                finally
                {
                    debug("Restart handled");
                }
            }
        }
        if(showWinScreen) {
            Cursor.lockState = CursorLockMode.Confined;
            if (GUI.Button(new Rect(Screen.width/2 - 100,Screen.height/2 - 50,200,100),"You Escaped!"))
            {
                Utilities.RestartLevel();
            }
        }
    }
    
}
