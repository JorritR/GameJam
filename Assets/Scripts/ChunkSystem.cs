using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunkSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject chunkPrefab;
    private List<Vector2Int> loadedChunks = new List<Vector2Int> { new Vector2Int(0, 0) };

    void Start()
    {
    }

    private void spawnChunk(Vector2Int newChunkIndex)
    {
        if (loadedChunks.Contains(newChunkIndex))
        {
            return;
        }
        int randomRotation = Random.Range(0, 3);
        Vector3 newChunkPos = new Vector3(newChunkIndex.x * 40, newChunkIndex.y * 40, 0);
        GameObject newChunk = Instantiate(chunkPrefab, newChunkPos, Quaternion.Euler(new Vector3(0, 0, randomRotation * 90)));
        newChunk.GetComponent<ChunkData>().chunkIndex = newChunkIndex;
        loadedChunks.Add(newChunkIndex);
    }

    void Update()
    {
        Vector3 playerPos = transform.position;
        Vector2Int currentChunkIndex = new Vector2Int(Mathf.RoundToInt(playerPos.x / 40), Mathf.RoundToInt(playerPos.y / 40));

        Vector3 chunkCenter = new Vector3(currentChunkIndex.x * 40, currentChunkIndex.y * 40, 0);

        // Player is to the left of the chunk
        if (playerPos.x - chunkCenter.x < 2)
        {
            Vector2Int newChunkIndex = new Vector2Int(currentChunkIndex.x - 1, currentChunkIndex.y);

            spawnChunk(newChunkIndex);

            Vector2Int newChunkIndexAbove = new Vector2Int(currentChunkIndex.x - 1, currentChunkIndex.y + 1);
            Vector2Int newChunkIndexBelow = new Vector2Int(currentChunkIndex.x - 1, currentChunkIndex.y - 1);

            spawnChunk(newChunkIndexAbove);
            spawnChunk(newChunkIndexBelow);
        }
        
        // Player is to the right of the chunk
        if (playerPos.x - chunkCenter.x > 2)
        {
            Vector2Int newChunkIndex = new Vector2Int(currentChunkIndex.x + 1, currentChunkIndex.y);

            spawnChunk(newChunkIndex);

            Vector2Int newChunkIndexAbove = new Vector2Int(currentChunkIndex.x + 1, currentChunkIndex.y + 1);
            Vector2Int newChunkIndexBelow = new Vector2Int(currentChunkIndex.x + 1, currentChunkIndex.y - 1);

            spawnChunk(newChunkIndexAbove);
            spawnChunk(newChunkIndexBelow);
        }

        // Player is to the top of the chunk
        if (playerPos.y - chunkCenter.y > 0)
        {
            Vector2Int newChunkIndex = new Vector2Int(currentChunkIndex.x, currentChunkIndex.y + 1);

            spawnChunk(newChunkIndex);

            Vector2Int newChunkIndexLeft = new Vector2Int(currentChunkIndex.x - 1, currentChunkIndex.y + 1);
            Vector2Int newChunkIndexRight = new Vector2Int(currentChunkIndex.x + 1, currentChunkIndex.y + 1);

            spawnChunk(newChunkIndexLeft);
            spawnChunk(newChunkIndexRight);
        }

        // Player is to the bottom of the chunk
        if (playerPos.y - chunkCenter.y < 0)
        {
            Vector2Int newChunkIndex = new Vector2Int(currentChunkIndex.x, currentChunkIndex.y - 1);

            spawnChunk(newChunkIndex);

            Vector2Int newChunkIndexLeft = new Vector2Int(currentChunkIndex.x - 1, currentChunkIndex.y - 1);
            Vector2Int newChunkIndexRight = new Vector2Int(currentChunkIndex.x + 1, currentChunkIndex.y - 1);

            spawnChunk(newChunkIndexLeft);
            spawnChunk(newChunkIndexRight);
        }
        


    }


}
