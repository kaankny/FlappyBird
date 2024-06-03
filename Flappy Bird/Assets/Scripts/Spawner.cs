using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameSettings gameSettings;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), gameSettings.spawnDelay, gameSettings.spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        Pipes pipes = Instantiate(gameSettings.pipePrefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(gameSettings.minHeight, gameSettings.maxHeight);
        pipes.gameSettings.pipeGap= gameSettings.verticalGap;
    }

}
