using System.Collections;
using System.Collections.Generic;
using Devdog.General;
using Devdog.QuestSystemPro;
using Devdog.QuestSystemPro.Dialogue;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Object responsible for managing all the always-present controllers needed for gameplay.
/// </summary>
[RequireComponent(typeof(DialogueManager))] //runs dialog system
[RequireComponent(typeof(QuestManager))] //runs devdog quest system
[RequireComponent(typeof(InputManager))] //runs DevDog Input system TODO: See about merging with CrossPlatormInputManager
[RequireComponent(typeof(PlayerManager))] //runs devdog Player Manager system TODO: See about merging with our PlayerManager
[RequireComponent(typeof(GeneralSettingsManager))] //runs devdog settings system TODO: See if custom settings can be added and used
[RequireComponent(typeof(AudioManager))] //runs Audio system
//TODO: Consider making Singleton
public class GameManager : MonoBehaviour {

    public GameManager()
    {
    }

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(EventSystem.current.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
