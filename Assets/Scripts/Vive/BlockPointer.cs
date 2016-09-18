using UnityEngine;
using System.Collections;

public class BlockPointer : ViveController
{
    public LayerMask blockLayer;
    public Block selectedBlock;
	
	// Update is called once per frame
	void Update ()
    {
        UpdateSelectedBlock();
	}

    void UpdateSelectedBlock ()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, blockLayer))
        {
            Block block = hit.transform.GetComponent<Block>();
            if (block != selectedBlock)
            {
                selectedBlock = block;
            }
        }
        else
        {
            selectedBlock = null;
        }
    }
}
