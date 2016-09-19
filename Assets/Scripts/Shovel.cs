using UnityEngine;
using System.Collections;

public class Shovel : MonoBehaviour
{
    public GameObject ground;

    BlockPointer _pointer;
    BlockPointer pointer
    {
        get
        {
            if (_pointer == null)
            {
                _pointer = GetComponentInParent<BlockPointer>();
            }
            return _pointer;
        }
    }

    void OnTriggerEnter (Collider other)
    {   
        if (other.gameObject == ground)
        {
            if (pointer.selectedBlock != null)
            {
                pointer.selectedBlock.Excavate();
            }
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject == ground)
        {
            if (pointer.selectedBlock != null)
            {
                pointer.selectedBlock.Excavate();
            }
        }
    }
}
