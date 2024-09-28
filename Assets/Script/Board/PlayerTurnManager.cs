using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Script
{
   public class PlayerTurnManager
    {
        GameObject[] playersTimeLine;
        int timeLinePos = 0;

        public PlayerTurnManager(GameObject[] playersTimeLine)
        {
            this.playersTimeLine = playersTimeLine;
            this.playersTimeLine = playersTimeLine.OrderByDescending(x => x.GetComponent<Player>().GetInitiative()).ToArray();
        }

        public GameObject[] GetPlayersTimeline() { return playersTimeLine; }
        public GameObject GetCurrentPlayer() { return playersTimeLine[timeLinePos]; }
         public void AdvanceTimeLine() { 

            timeLinePos++;          
            timeLinePos = timeLinePos >= playersTimeLine.Length ? 0 : timeLinePos;
        }

    }
}
