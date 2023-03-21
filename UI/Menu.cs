using Data;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

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

        private GUIStyle labelStyle;
        private GUIStyle textFieldStyle;
        private GUIStyle buttonStyle;

        public void Update()
        {
            if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetKeyUp(KeyCode.S))
            {
                showMenu = !showMenu;
            }
        }

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

            windowRect = GUI.Window(657461330, windowRect, Fill, "Seed menu - Alt+S to toggle");
        }

        private void CalculateSizing()
        {
            wUnit = Screen.width / 50;
            hUnit = Screen.height / 50;

            labelStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = (int)hUnit
            };

            textFieldStyle = new GUIStyle(GUI.skin.textField)
            {
                fontSize = (int)hUnit
            };

            buttonStyle = new GUIStyle(GUI.skin.button)
            {
                fontSize = (int)hUnit
            };
        }

        private void Resize()
        {
            menuWidth = (int)(wUnit * 10);
            menuHeight = (int)(hUnit * 7);

            windowRect = new Rect(Screen.width - menuWidth - wUnit, hUnit, menuWidth, menuHeight);
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

            GUI.Label(seedLabelRect, "Seed:", labelStyle);
            SetSeedFromString(GUI.TextField(seedTextfieldRect, GameData.Save.instance._randomSeed._value.ToString(), textFieldStyle));
            
            if (GUI.Button(randomizeButtonRect, "Randomize", buttonStyle))
            {
                GameData.Save.instance._randomSeed._value = Random.Range(int.MinValue, int.MaxValue);
            }
        }

        private void SetSeedFromString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                GameData.Save.instance._randomSeed._value = 0;
                return;
            }

            bool success = int.TryParse(input, out int parsed);

            if (success)
            {
                GameData.Save.instance._randomSeed._value = parsed;
            }
        }
    }
}
