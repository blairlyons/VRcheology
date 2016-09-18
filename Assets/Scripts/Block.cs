using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
public class Block : MonoBehaviour 
{
    public bool excavated;
	public Vector3 location;

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
        boxCollider.center = location.y * Vector3.up;
		name = GetType().ToString() + "_" + location.x + ":" + location.y + ":" + location.z;
        CheckVisibility();
	}

    public virtual void Excavate ()
    {
        if (!excavated)
        {
            excavated = true;
            CheckVisibility();
        }
    }

    public void CheckVisibility ()
    {
        if (AtSurface)
        {
            if (!meshRenderer.enabled)
            {
                meshRenderer.enabled = boxCollider.enabled = true;
            }
        }
        else
        {
            if (meshRenderer.enabled)
            {
                meshRenderer.enabled = boxCollider.enabled = false;
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
            return !excavated && (blockAbove == null || blockAbove.excavated);
        }
    }
}
