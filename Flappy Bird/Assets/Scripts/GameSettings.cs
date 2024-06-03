using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [Header("Player Settings")]
        public List<Sprite> playerAnimationSprites;
        public float playerStrength = 5f;
        public float playerGravity = -9.81f;
        public float playerTilt = 5f;
        public float playerAnimationSpeed = 0.15f;
        public float playerAnimationDelay = 0.15f;

        [Header("Spawner Settings")]
        public Pipes pipePrefab;
        public float spawnRate = 1f;
        public float spawnDelay = 1f;        
        public float minHeight = -1f;
        public float maxHeight = 2f;
        public float verticalGap = 3f;

        [Header("Pipe Settings")]
        public float pipeSpeed = 5f;
        public float pipeGap = 3f;

        [Header("Game Settings")]
        public int targetFrameRate = 60;
        public KeyCode playerJumpKey = KeyCode.Space;
        public float backgroundScrollSpeed = 0.03f;
        public float groundScrollSpeed = 1f;
        public int scorePerPipe = 1;
    }