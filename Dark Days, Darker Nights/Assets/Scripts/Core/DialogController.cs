using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkDays.Core
{
    /// <summary>
    /// Controls our Dialog Engine and provides and interface for the player to call up the needed dialog and it's effects.
    /// </summary>
    public class DialogController : MonoBehaviour
    {

        

        // Use this for initialization
        void Start()
        {
            var currentDialog = DialogueManager.LoadDialogueFile("OutsideOfficer");
            var conversation = currentDialog.GetDialogue("Start");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
