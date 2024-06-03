using UnityEngine;

public class Pipes : MonoBehaviour
{
    public GameSettings gameSettings;
    public Transform top;
    public Transform bottom;

    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        top.position += Vector3.up * gameSettings.pipeGap / 2;
        bottom.position += Vector3.down * gameSettings.pipeGap / 2;
    }

    private void Update()
    {
        transform.position += gameSettings.pipeSpeed * Time.deltaTime * Vector3.left;

        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }

}
