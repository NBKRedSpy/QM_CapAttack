using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QM_CapAttack
{

    [HarmonyPatch(typeof(Creature), nameof(Creature.MeleeAttack),
        typeof(int), typeof(int), typeof(Creature), typeof(bool))]
    public static class Monster_MeleeAttack_Patch
    {
        public static bool Prefix(Creature __instance)
        {
            //Only apply to  monster instances.
            //There  should only be Creature (which is the base), and Player, which is not affected.
            if (__instance as Monster == null) return true;

            AiBehaviour_ProcessActionPoint__Patch.MeleeAttacks++;

            if (AiBehaviour_ProcessActionPoint__Patch.MeleeAttacks > 2)
            {
#if DEBUG
                Debug.LogWarning($"Attacks Reached: {__instance.Record.Id} {AiBehaviour_ProcessActionPoint__Patch.MeleeAttacks}");
#endif
                return false;
            }

#if DEBUG
            Debug.Log($"Allow Attack: {__instance.Record.Id} {AiBehaviour_ProcessActionPoint__Patch.MeleeAttacks}");
#endif
            return true;
        }
    }
}
