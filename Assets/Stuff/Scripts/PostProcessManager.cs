using UnityEngine;
using System.Collections;

public class PostProcessManager : MonoBehaviour {
	
	private Bloom bloom;
	private DepthOfFieldScatter dof;
	
	private bool bUpdateBloom;
	private bool bUpdateDoF;
	
	public float targetBloomStrength;
	public float targetDofAperture;
	
	public float transitionSpeed = 1.0f;
	
	// Use this for initialization
	void Start () {
		bloom = GetComponent<Bloom>();
		if(bloom != null){
			bUpdateBloom = true;
			targetBloomStrength = bloom.bloomIntensity;
		}
		dof = GetComponent<DepthOfFieldScatter>();
		if(dof != null){
			bUpdateDoF = true;
			targetDofAperture = dof.aperture;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(bUpdateBloom){
			bloom.bloomIntensity = Mathf.Lerp(bloom.bloomIntensity, targetBloomStrength, transitionSpeed * Time.deltaTime);
		}
		
		if(bUpdateDoF){
			dof.aperture = Mathf.Lerp(dof.aperture, targetDofAperture, transitionSpeed * Time.deltaTime);
		}
	}
}

