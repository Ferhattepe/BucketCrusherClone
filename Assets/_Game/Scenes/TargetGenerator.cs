using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    public Texture2D pixelArtImage;
    public MeshRenderer cubePrefab;

    void Start()
    {
        for (int i = 0; i < pixelArtImage.width; i++)
        {
            for (int j = 0; j < pixelArtImage.height; j++)
            {
                var pixel = pixelArtImage.GetPixel(i, j);
                var mesh = Instantiate(cubePrefab, transform);
                mesh.material.color = pixel;
                mesh.transform.localPosition = new Vector3(i, j, 0) * 0.2f;
            }
        }
    }
}




