using System.Linq;
using UnityEngine;

public class ParthenonBuilder : MonoBehaviour {

	public GameObject cubePrefab;
    public GameObject cylinderPrefab;

    public float floorWidth = 5.0f;
    public float floorDepth = 10.0f;
    public float floorHeight = 0.25f;
    public float pillarRadius = 0.2f;
    public float pillarHeight = 2.0f;
    public int pillarCountWidth = 6;
    public int pillarCountDepth = 10;
    public float roofHeight = 1.0f;
    public Material floorMaterial;
    public Material pillarMaterial;
    public Material roofMaterial;

    private Vector3 upperFloorScale;
    private Vector3 upperFloorPosition;

    [ContextMenu("Build floor")]
    void MakeParthenonfloor()
    {

        float floorScale = 1;
        float floorY = transform.position.y;

        foreach (Transform t in transform.Cast<Transform>().ToArray())
        {
            DestroyImmediate(t.gameObject);
        }

        for (int i = 0; i < 3; i++)
        {
            var floor = Instantiate(cubePrefab, transform);
            var tr = floor.transform;
            tr.localScale = new Vector3(floorWidth* floorScale, floorHeight, floorDepth* floorScale);
            upperFloorScale = new Vector3(floorWidth * floorScale, 0, floorDepth * floorScale);            
            tr.localPosition = new Vector3(transform.position.x, floorY, transform.position.z);
            upperFloorPosition = new Vector3(transform.position.x, floorY, transform.position.z);
            floorScale *= 0.9f;
            floorY += floorHeight;
        }

        float distWidth = (upperFloorScale.x - pillarRadius) / (pillarCountWidth - 1);
        float distDepth = (upperFloorScale.z - pillarRadius) / (pillarCountDepth - 1);

        for (int i = 0; i < pillarCountWidth; i++)
        {
            var pillar = Instantiate(cylinderPrefab, transform);
            var tr = pillar.transform;
            tr.localScale = new Vector3(pillarRadius, pillarHeight/2, pillarRadius);
            tr.localPosition = new Vector3(upperFloorPosition.x + (-upperFloorScale.x + pillarRadius) / 2 + distWidth * i, upperFloorPosition.y, upperFloorPosition.z + (-upperFloorScale.z + pillarRadius) / 2);

        }
        for (int i = 0; i < pillarCountWidth; i++)
        {
            var pillar = Instantiate(cylinderPrefab, transform);
            var tr = pillar.transform;
            tr.localScale = new Vector3(pillarRadius, pillarHeight/2, pillarRadius);
            tr.localPosition = new Vector3(upperFloorPosition.x + (-upperFloorScale.x + pillarRadius) / 2 + distWidth * i, upperFloorPosition.y, upperFloorPosition.z - (-upperFloorScale.z + pillarRadius) / 2);

        }

        for (int i = 1; i < pillarCountDepth - 1; i++)
        {
            var pillar = Instantiate(cylinderPrefab, transform);
            var tr = pillar.transform;
            tr.localScale = new Vector3(pillarRadius, pillarHeight/2, pillarRadius);
            tr.localPosition = new Vector3(upperFloorPosition.x + (-upperFloorScale.x + pillarRadius) / 2, upperFloorPosition.y, upperFloorPosition.z + (-upperFloorScale.z + pillarRadius) / 2 + distDepth * i);

        }
        for (int i = 1; i < pillarCountDepth - 1; i++)
        {
            var pillar = Instantiate(cylinderPrefab, transform);
            var tr = pillar.transform;
            tr.localScale = new Vector3(pillarRadius, pillarHeight/2, pillarRadius);
            tr.localPosition = new Vector3(upperFloorPosition.x - (-upperFloorScale.x + pillarRadius) / 2, upperFloorPosition.y, upperFloorPosition.z + (-upperFloorScale.z + pillarRadius) / 2 + distDepth * i);

        }


        var roof = Instantiate(cubePrefab, transform);
        var tr_roof = roof.transform;
        tr_roof.localScale = new Vector3 (upperFloorScale.x, roofHeight, upperFloorScale.z);
        tr_roof.localPosition = new Vector3(transform.position.x, upperFloorPosition.y + pillarHeight, transform.position.z);



    }

    
}
