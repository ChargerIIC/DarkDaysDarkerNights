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
        private Dialogue.Choice currentChoice;
        private Dialogue conversation;

        public DialogueFile dialogFile = null;
        public List<Texture2D> images = new List<Texture2D>();

        // Use this for initialization
        void Start()
        {
            var currentDialog = DialogueManager.LoadDialogueFile(dialogFile);
            conversation = currentDialog.GetDialogue("Introduction");
            currentChoice = conversation.GetChoices()[0];
            conversation.PickChoice(currentChoice);

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LoadConversation(GameObject target)
        {
            //TODO: LOad Character's dialog
            //var npc = target.GetComponent<NPC>();
            //var dialog = npc.CurrentDialog;
        }

        public void StartConversation()
        {
            GUILayout.BeginArea(new Rect(10, 10, 680, 560));
            GUILayout.Label(currentChoice.dialogue);
            if (conversation.GetChoices().Length > 1)
            {
                // sort list
                Dialogue.Choice[] list = conversation.GetChoices();
                System.Array.Sort(list, (o1, o2) => o1.userData.CompareTo(o2.userData));

                GUILayout.BeginVertical();
                foreach (Dialogue.Choice choice in list)
                {
                    if (GUILayout.Button(choice.dialogue))
                    {
                        conversation.PickChoice(choice);
                        currentChoice = choice;
                    }
                }
                GUILayout.EndVertical();
            }
            else if (conversation.GetChoices().Length == 1)
            {
                if (GUILayout.Button("Next"))
                {
                    currentChoice = conversation.GetChoices()[0];
                    conversation.PickChoice(currentChoice);
                }

                // check if we need to display an image
                if (currentChoice.userData.IndexOf("image:") == 0)
                {
                    Debug.Log(currentChoice.userData.Substring(6));
                    int imageIndex = int.Parse(currentChoice.userData.Substring(6));
                    Texture2D tex = images[imageIndex];
                    GUI.DrawTexture(new Rect(0, 100, tex.width, tex.height), tex);
                }
            }
            else
            {
                // end of tutorial
            }

            GUILayout.EndArea();
        }

    }
}
