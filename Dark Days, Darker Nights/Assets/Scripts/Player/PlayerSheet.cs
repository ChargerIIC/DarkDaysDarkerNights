using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkDays.Player
{

    /// <summary>
    /// DTO Class for holding the stats of the player, such as those
    /// found on a paper RPG's player sheet. SHould be as little code as possible
    /// </summary>
    public class PlayerSheet : ScriptableObject
    {

        public string Name;
        public string Rank = "Junior Detective";

    }
}
