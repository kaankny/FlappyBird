using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameSettings gameSettings;

    public bool isBackground;
    private float animationSpeed;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        animationSpeed = isBackground ? gameSettings.backgroundScrollSpeed : gameSettings.groundScrollSpeed;
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }

}
