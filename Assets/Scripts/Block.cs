using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
public class Block : MonoBehaviour 
{
    public int excavated = 2;
	public Vector3 location;

    public MeshRenderer fullGeometry;
    public MeshRenderer halfGeometry;
    MeshRenderer currentGeometry;

    BlockFactory _factory;
    BlockFactory factory
    {
        get
        {
            if (_factory == null)
            {
                _factory = GetComponentInParent<BlockFactory>();
            }
            return _factory;
        }
    }

    MeshRenderer _meshRenderer;
    public MeshRenderer meshRenderer
    {
        get
        {
            if (_meshRenderer == null)
            {
                _meshRenderer = GetComponent<MeshRenderer>();
            }
            return _meshRenderer;
        }
    }

    BoxCollider _boxCollider;
    BoxCollider boxCollider
    {
        get
        {
            if (_boxCollider == null)
            {
                _boxCollider = GetComponent<BoxCollider>();
            }
            return _boxCollider;
        }
    }

    public virtual void Init (Vector3 _location)
	{
		location = _location;
		transform.localPosition = new Vector3(location.x, -location.y, location.z);
        //boxCollider.center = location.y * Vector3.up;
		name = GetType().ToString() + "_" + location.x + ":" + location.y + ":" + location.z;
        CheckVisibility();
	}

    public virtual void Excavate ()
    {
        if (excavated > 0)
        {
            excavated--;
            CheckVisibility();
        }
    }

    public void CheckVisibility ()
    {
        if (AtSurface)
        {
            Debug.Log(name + " at surface");
            //if (!boxCollider.enabled)
            //{
                boxCollider.enabled = true;
                if (excavated == 2)
                {
                    Debug.Log("excavate 2");
                    fullGeometry.enabled = true;
                    halfGeometry.enabled = false;
                }
                else if (excavated == 1)
                {
                    Debug.Log("excavate 1");
                    fullGeometry.enabled = false;
                    halfGeometry.enabled = true;
                }
            //}
        }
        else
        {
            if (boxCollider.enabled)
            {
                Debug.Log("hide");
                boxCollider.enabled = fullGeometry.enabled = halfGeometry.enabled = false;

                Block blockBelow = factory.GetBlockBelow(location);
                if (blockBelow != null)
                {
                    blockBelow.CheckVisibility();
                }
            }
        }
    }

    bool AtSurface
    {
        get
        {
            Block blockAbove = factory.GetBlockAbove(location);
            return excavated > 0 && (blockAbove == null || blockAbove.excavated == 0);
        }
    }
}
