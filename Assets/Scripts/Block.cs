using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 
{
	public Vector3 location;

	public virtual void Init (Vector3 _location)
	{
		location = _location;
		transform.localPosition = new Vector3(location.x, -location.z, location.y);
		name = GetType().ToString() + "_" + location.x + ":" + location.y + ":" + location.z;
	}
}
