using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {

	private const int bufferFrames = 100;
	private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
	private Rigidbody rBody;
	private GameManager gMan;

	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody> ();
		gMan = FindObjectOfType<GameManager> ();
	}
	
	void Update () {
		if (gMan.recording == true) {
			Record();
		} else {
			PlayBack();
		}
	}


	public void PlayBack () {
		rBody.isKinematic = true;
		int frame = Time.frameCount % bufferFrames;
		transform.position = keyFrames [frame].position;
		transform.rotation = keyFrames [frame].rotation;
	}

	public void Record ()
	{
		rBody.isKinematic = false;
		int frame = Time.frameCount % bufferFrames;
		float time = Time.time;
		keyFrames [frame] = new MyKeyFrame (time, transform.position, transform.rotation);
	}
}

/// <summary>
///  A structure for storing time, position and rotation.
/// </summary>
public struct MyKeyFrame{

	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;

	public MyKeyFrame (float time, Vector3 pos, Quaternion rot) {
		frameTime = time;
		position = pos;
		rotation = rot;
	}
}
