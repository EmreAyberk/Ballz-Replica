using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;

    private int playWidth = 8;
    private float distanceBetweenBlocks = 0.7f;
    private int rowSpanwed;

    private List<Block> blocksSpawned = new List<Block>();
    private void OnEnable()
    {
        SpawnRowOfBlocks();
        
    }

    public void SpawnRowOfBlocks()
    {
        foreach (var blocks in blocksSpawned)
        {
            if (blocks != null)
            {
                blocks.transform.position += Vector3.down * distanceBetweenBlocks;
            }
        }
        for (int i = 0; i < playWidth; i++)
        {
            if (UnityEngine.Random.Range(0, 100) <= 30)
            {
                var block = Instantiate(blockPrefab, GetPosition(i), Quaternion.identity);
                int hits = UnityEngine.Random.Range(1, 4) + rowSpanwed;

                block.SetHits(hits);
                blocksSpawned.Add(block);
            }
        }

        rowSpanwed += 2;
    }

    private Vector3 GetPosition(int i)
    {
        Vector3 position = transform.position;
        position += Vector3.right * i * distanceBetweenBlocks;
        return position;
    }
}
