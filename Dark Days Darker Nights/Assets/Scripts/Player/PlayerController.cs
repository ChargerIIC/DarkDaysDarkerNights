using System;
using System.Collections;
using System.Collections.Generic;
//using DarkDays.Dialog;
using DarkDays.Enum;
using UnityEngine;

namespace DarkDays.Player
{
    public class PlayerController : MonoBehaviour
    {

        #region Class Level Variable

        private CameraRaycaster rayCaster;

        #endregion Class Level Variable 

        // Use this for initialization
        void Start()
        {
            GameObject.DontDestroyOnLoad(this);
            rayCaster = FindObjectOfType<CameraRaycaster>();
            rayCaster.notifyMouseClickObservers += ProcessMouseClick;
        }

        private void ProcessMouseClick(RaycastHit raycastHit, int layerHit)
        {
            if (layerHit == (int)Layers.Npc)
            {
                //FindObjectOfType<DialogController>().StartConversation();//TODO: Will grab dialogfile from NPC and pass in
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}