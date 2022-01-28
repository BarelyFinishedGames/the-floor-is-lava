using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public Transform plane;
    private float planeX;
    public float radius;

    private float planeZ;
    // Start is called before the first frame update
    void Start()
    {
        planeX = plane.GetComponent<Collider>().bounds.size.x/2;
        planeZ = plane.GetComponent<Collider>().bounds.size.z/2;
        for (int i = 0; i < 20; i++)
        {
            SpawnObstaclesMethod(radius);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstaclesMethod(float radius, int numSamplesBeforeRejection = 30)
    {
        float cellSize = radius / Mathf.Sqrt(2);
        int[,] grid = new int[Mathf.CeilToInt(planeX/cellSize), Mathf.CeilToInt(planeZ/cellSize)];
        List<Vector2> points = new List<Vector2>();
        List<Vector2> spawnPoints = new List<Vector2>();

        spawnPoints.Add(new Vector2(Random.Range(-planeX, planeX),Random.Range(-planeZ, planeZ)));
        while (spawnPoints.Count>0)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Count);
            Vector2 spawnCentre = spawnPoints[spawnIndex];
            bool candidateAccepted = false;
            for (int i = 0; i < numSamplesBeforeRejection; i++)
            {
                float angle = Random.value * Mathf.PI * 2;
                Vector2 dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
                Vector2 candidate = spawnCentre * dir * Random.Range(radius, 2 * radius);
                if (IsValid(candidate, cellSize, radius, points, grid))
                {
                    points.Add(candidate);
                    spawnPoints.Add(candidate);
                    grid[(int) (candidate.x / cellSize), (int) (candidate.y / cellSize)] = points.Count;
                    candidateAccepted = true;
                    break;
                }
            }

            if (!candidateAccepted)
            {
                spawnPoints.RemoveAt(spawnIndex);
            }
        }

        if (points != null)
        {
            foreach (var point in points)
            {
                GameObject obj = Instantiate(this.obstacle);
                obj.transform.position = new Vector3(point.x, 0, point.y);
                obj.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private bool IsValid(Vector2 candidate, float cellSize, float radius, List<Vector2> points, int[,] grid)
    {
        if (candidate.x >= 0 && candidate.x < planeX && candidate.y >= 0 && candidate.y < planeZ)
        {
            int cellX = (int) (candidate.x / cellSize);
            int cellY = (int) (candidate.y / cellSize);
            int searchStartX = Mathf.Max(0,cellX - 2);
            int searchEndX = Mathf.Min(cellX + 2, grid.GetLength(0) - 1);
            int searchStartY = Mathf.Max(0,cellY - 2);
            int searchEndY = Mathf.Min(cellY + 2, grid.GetLength(1) - 1);

            for (int x = searchStartX; x <= searchEndX; x++)
            {
                for (int y = searchStartY; y <=searchEndY; y++)
                {
                    int pointIndex = grid[x, y] - 1;
                    if (pointIndex != -1)
                    {
                        float sqrDst = (candidate - points[pointIndex]).sqrMagnitude;
                        if (sqrDst < radius*radius)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        return false;
    }
}
