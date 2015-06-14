using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransformTracker : MonoBehaviour {
	[System.Serializable]
	public class TransformBackup {
		public Vector3 position;
		public Quaternion rotation;
	}
	public List<TransformBackup> storedTransforms;


	void Reset() {
		storedTransforms = new List<TransformBackup>();
	}

	public void LoadStored (TransformTracker.TransformBackup item)
	{
		this.gameObject.transform.position = item.position;
		this.gameObject.transform.rotation = item.rotation;
	}

	public void DeleteStored (TransformTracker.TransformBackup item)
	{
		this.storedTransforms.Remove(item);
	}

	public void SaveCurrent ()
	{
		var item = new TransformTracker.TransformBackup();
		item.position = this.gameObject.transform.position;
		item.rotation = this.gameObject.transform.rotation;
		this.storedTransforms.Add(item);
	}
}
