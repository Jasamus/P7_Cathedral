using UnityEngine;
using System.Collections;

public class PostProcessVolume : MonoBehaviour {

	public float bloomIntensity;
	public float dofAperture;
	
	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			PostProcessManager ppm = other.GetComponentInChildren<PostProcessManager>();
			ppm.targetBloomStrength = bloomIntensity;
			ppm.targetDofAperture = dofAperture;
		}
	}
}
