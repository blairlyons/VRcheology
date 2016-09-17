using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockFactory : MonoBehaviour 
{
	public Block blockPrefab;
	public Block animalBonePrefab;
	public Block potteryPrefab;
	public Block objectPrefab;

	public Vector3 size;
	public Block[,,] blocks;
	public Queue<Feature> features = new Queue<Feature>();

	Feature nextFeature = null;

	void Start ()
	{
		MakeTestFeatures();
		GenerateBlocks();
	}

	void GenerateBlocks ()
	{
		if (blockPrefab != null && blockPrefab.GetComponent<Block>())
		{
			if (features.Count > 0) 
			{
				nextFeature = features.Dequeue();
			}

			blocks = new Block[Mathf.RoundToInt(size.x), Mathf.RoundToInt(size.y), Mathf.RoundToInt(size.z)];
			for (int u = 0; u < size.x; u++)
			{
				for (int v = 0; v < size.y; v++)
				{
					for (int w = 0; w < size.z; w++)
					{
						Vector3 location = new Vector3(u, v, w);

						blocks[u, v, w] = CreateBlock( GetType(location) );
						blocks[u, v, w].transform.SetParent(transform);
						blocks[u, v, w].Init(location);
					}
				}
			}
		}
	}

	FeatureType GetType (Vector3 location)
	{
		FeatureType type = FeatureType.None;
		if (nextFeature != null && nextFeature.location == location) 
		{
			type = nextFeature.type;
			Debug.Log("Making " + type.ToString() + " at " + location);
			if (features.Count > 0) 
			{
				nextFeature = features.Dequeue();
			}
			else
			{
				nextFeature = null;
			}
		}
		return type;
	}

	Block CreateBlock (FeatureType type)
	{
		switch (type)
		{
		case FeatureType.AnimalBone :
			
			return Instantiate(animalBonePrefab).GetComponent<Block>();

		case FeatureType.Object :

			return Instantiate(objectPrefab).GetComponent<Block>();

		case FeatureType.Pottery :

			return Instantiate(potteryPrefab).GetComponent<Block>();

		default :

			return Instantiate(blockPrefab).GetComponent<Block>();
		}
	}

	void MakeTestFeatures ()
	{
		features.Enqueue(new Feature(new Vector3(1, 5, 2), FeatureType.Pottery, null));
		features.Enqueue(new Feature(new Vector3(3, 0, 3), FeatureType.Pottery, null));
		features.Enqueue(new Feature(new Vector3(4, 3, 3), FeatureType.Object, null));
		features.Enqueue(new Feature(new Vector3(5, 5, 2), FeatureType.AnimalBone, null));
	}
}
