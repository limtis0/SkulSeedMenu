using HarmonyLib;
using Level;
using SkulSeedMenu.UI;
using System;

namespace SkulSeedMenu.Patches
{
    [HarmonyPatch(typeof(LevelManager), nameof(LevelManager.Load), new Type[] { typeof(int) })]
    public static class ToggleMenuPatch
    {
        public static void Postfix(int chapterIndex)
        {
            Chapter.Type chapter = (Chapter.Type)chapterIndex;

            if (chapter == Chapter.Type.Castle || chapter == Chapter.Type.HardmodeCastle)
            {
                Menu.showMenu = true;
            }
            else
            {
                Menu.showMenu = false;
            }
        }
    }
}
