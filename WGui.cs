using BepInEx;
using GorillaNetworking;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace JoesTemp
{
    [BepInPlugin("Joes", "GuiTemp", "1.0.1")]
    public class GUITEMP : BaseUnityPlugin
    {
        private Rect windowRect = new Rect(0, 0, 550, 650);
        private string codeInput = "";
        private bool showGUI = true; // Variable to control GUI visibility

        private void Update()
        {
            // Toggle GUI visibility with F2 key
            if (Input.GetKeyDown(KeyCode.F2))
            {
                showGUI = !showGUI;
            }
        }

        private void OnGUI()
        {
            if (showGUI) // Check if GUI should be shown
            {
                GUI.backgroundColor = Color.clear;
                windowRect = GUILayout.Window(0, windowRect, MainGUI, "");
            }
        }

        private void MainGUI(int windowID)
        {
            GUI.skin.box.normal.textColor = new Color32(153, 153, 255, 255);

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();

            GUILayout.Label("<color=yellow>AMCFlaco Gold [f2 to close]</color>", GUILayout.Width(100));
            GUILayout.BeginVertical("box");
            GUILayout.Label("Room Code:");
            GUILayout.BeginHorizontal();
            codeInput = GUILayout.TextField(codeInput, GUILayout.Width(100));
            if (GUILayout.Button("Join", GUILayout.Width(150), GUILayout.Height(25)))
            {
                PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(codeInput);
            }
            GUILayout.EndHorizontal();
            // Add more room-related GUI elements here if needed
            GUILayout.EndVertical();



            GUILayout.EndVertical();

            GUI.DragWindow();
        }
    }
}