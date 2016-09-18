using UnityEngine;
using System.Collections;

public class Shovel : MonoBehaviour {

	void OnTriggerEnter (Collider other)
    {
        Block block = other.GetComponent<Block>();
        if (block != null)
        {
            block.Excavate();
        }
    }
}
