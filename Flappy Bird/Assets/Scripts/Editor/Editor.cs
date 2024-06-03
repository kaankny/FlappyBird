using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace FlappyBirdTemplate
{
    public class Editor : EditorWindow
    {
        public GameSettings gameSettings;
        private int selected = 0;

        [MenuItem("Flappy Bird/Editor")]
        public static void ShowWindow()
        {
            GetWindow<Editor>("Flappy Bird");
        }
        
        private void DrawSettings()
        {
            
            DrawHeader();

            string[] options = new string[] { "Game Settings", "Player Settings", "Spawner Settings" };
            selected = GUILayout.Toolbar(selected, options);
            switch (selected)
            {
                case 0:
                    DrawGameSettings();
                    break;
                case 1:
                    DrawPlayerSettings();
                    break;
                case 2:
                    DrawSpawnerSettings();
                    break;
            }

            EditorGUILayout.EndVertical();
        }

        private void DrawHeader()
        {
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("FLAPPY BIRD EDITOR", EditorStyles.boldLabel);
            EditorGUILayout.Space();
        }

        private void DrawGameSettings()
        {
            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("Game Settings", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            gameSettings.targetFrameRate = EditorGUILayout.IntField("Target Frame Rate", gameSettings.targetFrameRate);
            gameSettings.backgroundScrollSpeed = EditorGUILayout.FloatField("Player Jump Key", gameSettings.backgroundScrollSpeed);
            gameSettings.groundScrollSpeed = EditorGUILayout.FloatField("Ground Scroll Speed", gameSettings.groundScrollSpeed);
            gameSettings.scorePerPipe = EditorGUILayout.IntField("Score Per Pipe", gameSettings.scorePerPipe);
            EditorGUILayout.EndVertical();
        }

        private void DrawPlayerSettings()
        {
            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("Player Settings", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            gameSettings.playerStrength = EditorGUILayout.FloatField("Player Strength", gameSettings.playerStrength);
            gameSettings.playerGravity = EditorGUILayout.FloatField("Player Gravity", gameSettings.playerGravity);
            gameSettings.playerTilt = EditorGUILayout.FloatField("Player Tilt", gameSettings.playerTilt);
            gameSettings.playerAnimationSpeed = EditorGUILayout.FloatField("Player Animation Speed", gameSettings.playerAnimationSpeed);
            gameSettings.playerAnimationDelay = EditorGUILayout.FloatField("Player Animation Delay", gameSettings.playerAnimationDelay);
            EditorGUILayout.LabelField("Player Animation", EditorStyles.boldLabel);
            
            if (GUILayout.Button("Add Animation Sprite"))
            {
                gameSettings.playerAnimationSprites.Add(null);
            }
            for (int i = 0; i < gameSettings.playerAnimationSprites.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                gameSettings.playerAnimationSprites[i] = (Sprite)EditorGUILayout.ObjectField(gameSettings.playerAnimationSprites[i], typeof(Sprite), false);
                var style = new GUIStyle(GUI.skin.button);
                style.normal.textColor = Color.red;
                style.fontStyle = FontStyle.Bold;
                style.fontSize = 12;
                style.alignment = TextAnchor.MiddleCenter;
                style.fixedHeight = 20f;
                if (GUILayout.Button("X", style, GUILayout.Width(20f)))
                {
                    gameSettings.playerAnimationSprites.RemoveAt(i);
                }
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndVertical();
        }

        private void DrawSpawnerSettings()
        {
            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("Spawner Settings", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            gameSettings.spawnRate = EditorGUILayout.FloatField("Spawn Rate", gameSettings.spawnRate);
            gameSettings.spawnDelay = EditorGUILayout.FloatField("Spawn Delay", gameSettings.spawnDelay);
            gameSettings.minHeight = EditorGUILayout.FloatField("Pipe Min Height", gameSettings.minHeight);
            gameSettings.maxHeight = EditorGUILayout.FloatField("Pipe Max Height", gameSettings.maxHeight);
            gameSettings.verticalGap = EditorGUILayout.FloatField("Vertical Gap", gameSettings.verticalGap);
            gameSettings.pipeSpeed = EditorGUILayout.FloatField("Pipe Speed", gameSettings.pipeSpeed);
            gameSettings.pipeGap = EditorGUILayout.FloatField("Pipe Gap", gameSettings.pipeGap);
            EditorGUILayout.EndVertical();
        }

        private void OnGUI()
        {
            if (gameSettings == null)
            {
                gameSettings = (GameSettings)EditorGUILayout.ObjectField("Game Settings", gameSettings, typeof(GameSettings), false);
                EditorGUILayout.HelpBox("Please assign a GameSettings object to continue.", MessageType.Warning);
                return;
            }
            DrawSettings();
        }
    }
}
