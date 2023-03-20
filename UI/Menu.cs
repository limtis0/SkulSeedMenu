using Data;
using UnityEngine;

namespace SkulSeedMenu.UI
{
    public class Menu : MonoBehaviour
    {
        public static bool showMenu = false;
        private bool init = false;

        // Sizing
        private float wUnit;
        private float hUnit;

        private int screenWidthPrevious;
        private int screenHeightPrevious;

        private int menuWidth;
        private int menuHeight;

        // Menu elements
        private Rect windowRect;
        private Rect dragWindowRect;
        private Rect seedLabelRect;
        private Rect seedTextfieldRect;
        private Rect randomizeButtonRect;

        public void OnGUI()
        {
            if (!showMenu)
            {
                return;
            }

            if (!init || Screen.height != screenHeightPrevious || Screen.width != screenWidthPrevious)
            {
                init = true;

                screenHeightPrevious = Screen.height;
                screenWidthPrevious = Screen.width;

                CalculateSizing();
                Resize();
            }

            windowRect = GUI.Window(657461330, windowRect, Fill, "Seed menu");
        }

        private void CalculateSizing()
        {
            wUnit = Screen.width / 50;
            hUnit = Screen.height / 50;
        }

        private void Resize()
        {
            menuWidth = (int)(wUnit * 10);
            menuHeight = (int)(hUnit * 7);

            windowRect = new Rect(Screen.width - menuWidth - wUnit * 2, hUnit, menuWidth, menuHeight);
            float row = 0;

            dragWindowRect = new Rect(0, 0, menuWidth, hUnit);
            row += 2;

            seedLabelRect = new Rect(wUnit, row * hUnit, wUnit * 3, hUnit * 1.5f);
            seedTextfieldRect = new Rect(wUnit * 3, row * hUnit, menuWidth - wUnit * 4, hUnit * 1.5f);
            row += 2.5f;

            randomizeButtonRect = new Rect(wUnit, row * hUnit, menuWidth - wUnit * 2, hUnit * 1.5f);
        }

        private void Fill(int _)
        {
            GUI.DragWindow(dragWindowRect);

            GUI.Label(seedLabelRect, "Seed:");
            SetSeedFromString(GUI.TextField(seedTextfieldRect, GameData.Save.instance._randomSeed._value.ToString()));
            
            if (GUI.Button(randomizeButtonRect, "Randomize"))
            {
                GameData.Save.instance._randomSeed._value = Random.Range(int.MinValue, int.MaxValue);
            }
        }

        private void SetSeedFromString(string seed) => int.TryParse(seed, out GameData.Save.instance._randomSeed._value);
    }
}
