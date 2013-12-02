using UnityEngine;
using System.Collections;

public class StretchTriggerLookDir : MonoBehaviour {
	
	private bool bUpdate;
	private Transform playerCam;

	public GameObject[] connectedStretch;
	private StretchBase[] stretch;
	public Vector3 stretchDir = new Vector3(0.0f,1.0f,0.01f);
	public float maxStretchAngle = 30.0f; //The angle away from looking in the correct direction that the movement will have maxed out
	public float startStretchAngle = 80.0f; //The angle away from looking in the correct direction that the movement will start
	
	// Use this for initialization
	void Start () {
		stretch = new StretchBase[connectedStretch.Length];

		for(int i = 0; i < connectedStretch.Length; i++){
			stretch[i] = connectedStretch[i].GetComponent<StretchBase>();
		}

		if(stretch.Length == 0){
			Debug.LogWarning("No connected stretcher to this...disabling");
			enabled = false;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			bUpdate = true;
			playerCam = other.GetComponentInChildren<Camera>().transform;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			bUpdate = false;
			for(int i = 0; i < stretch.Length; i++){
				stretch[i].UpdateStretch(0.0f,true);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if(bUpdate){
			//make sure we are at least looking at the direction before we care at all
			float viewAngle = Vector3.Angle(playerCam.forward, stretchDir);
			if(viewAngle < startStretchAngle){
				if(viewAngle < maxStretchAngle){
					viewAngle = 1.0f;
				}else{
					viewAngle = 1.0f - ((viewAngle - maxStretchAngle) / (startStretchAngle -maxStretchAngle));
				}
			}else
				viewAngle = 0.0f;

			for(int i = 0; i < stretch.Length; i++){
				if(stretch[i] != null)
					stretch[i].UpdateStretch(viewAngle);
			}
		}
	}
}
