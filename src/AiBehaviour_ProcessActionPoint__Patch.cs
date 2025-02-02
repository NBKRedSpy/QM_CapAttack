using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MGSC;

namespace QM_CapAttack
{
    [HarmonyPatch(typeof(AiBehaviour), nameof(AiBehaviour.ProcessActionPoint))]
    public static class AiBehaviour_ProcessActionPoint__Patch
    {
        /// <summary>
        /// The number of attacks this monster has executed this turn.
        /// </summary>
        public static int MeleeAttacks = 0;

        public static void Prefix(AiBehaviour __instance)
        {

            //Used to determine the start of a new turn.
            //Only monsters have the action cap
            Monster monster = __instance.Monster as Monster;

            if (monster == null) return;

            if (monster.ActionPointsProcessed == 0)
            { 
                MeleeAttacks = 0;
            }
        }
    }
}
