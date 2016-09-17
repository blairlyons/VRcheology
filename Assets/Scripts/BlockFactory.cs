using UnityEngine;
using System.Collections;

public class BlockFactory : MonoBehaviour 
{
	public GameObject blockPrefab;
	public Vector3 size;
	public Block[,,] blocks;

	void Start ()
	{
		GenerateBlocks();
	}

	void GenerateBlocks ()
	{
		if (blockPrefab != null && blockPrefab.GetComponent<Block>())
		{
			blocks = new Block[Mathf.RoundToInt(size.x), Mathf.RoundToInt(size.y), Mathf.RoundToInt(size.z)];
			for (int u = 0; u < size.x; u++)
			{
				for (int v = 0; v < size.y; v++)
				{
					for (int w = 0; w < size.z; w++)
					{
						blocks[u, v, w] = Instantiate(blockPrefab).GetComponent<Block>();
						blocks[u, v, w].transform.SetParent(transform);
						blocks[u, v, w].Init(new Vector3(u, v, w));
					}
				}
			}
		}
	}
}
