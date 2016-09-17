using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
public class Block : MonoBehaviour 
{
    public bool excavated;
	public Vector3 location;

	public virtual void Init (Vector3 _location)
	{
		location = _location;
		transform.localPosition = new Vector3(location.x, -location.z, location.y);
		name = GetType().ToString() + "_" + location.x + ":" + location.y + ":" + location.z;
	}

    public virtual void Excavate ()
    {
        if (!excavated)
        {
            excavated = true;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
