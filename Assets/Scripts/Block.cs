using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 
{
	public Vector3 location;

	public void Init (Vector3 _location)
	{
		location = _location;
		transform.localPosition = location;
		name = GetType().ToString() + "_" + location.x + ":" + location.y + ":" + location.z;
	}
}
