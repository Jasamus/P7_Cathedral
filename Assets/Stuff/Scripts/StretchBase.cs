using UnityEngine;
using System.Collections;
/*
 * This class manages all of the stretching of objects
 * 
 * TODO: change the UV scaling to include
 */
public class StretchBase : MonoBehaviour {
	
	public Vector3 stretchDir = new Vector3(0.0f,1.0f,0.0f);
	public Vector2 uvStretchDir = new Vector2(0.0f, 1.0f);
	public float stretchDist = 20.0f;
	
	public float maxStretchSpeed = 0.8f;

	private Transform fullTranslate;
	private Transform[] scaledTranslate;
	private Transform xStretch;
	private Transform yStretch;
	private Transform zStretch;

	//public float prevStretchPercent = 0.0f;
	private float currentStretchPercent;
	private float targetStretchPercent;
	private bool bForceUpdate;

	// Use this for initialization
	void Start () {
		fullTranslate = transform.Find("FullTranslate");
		xStretch = transform.Find("XScale");
		yStretch = transform.Find("YScale");
		zStretch = transform.Find("ZScale");

		Transform st = transform.Find("ScaledTranslate");
		if(st != null){
			scaledTranslate = new Transform[st.childCount];
			for(int i = 0; i < st.childCount; i++){
				scaledTranslate[i] = st.GetChild(i);
			}
		}

		if(fullTranslate.localPosition != Vector3.zero)
			Debug.LogWarning("No Scale failed to start at position 0,0,0");
		if(xStretch.localPosition != Vector3.zero)
			Debug.LogWarning("X Scale failed to start at position 0,0,0");
		if(yStretch.localPosition != Vector3.zero)
			Debug.LogWarning("Y Scale failed to start at position 0,0,0");
		if(zStretch.localPosition != Vector3.zero)
			Debug.LogWarning("Z Scale failed to start at position 0,0,0");

		//UpdateStretch(1.0f);
	}

	public void UpdateStretch(float newStretchPercent, bool bImmediateUpdate = false){
		targetStretchPercent = newStretchPercent;
		if(bImmediateUpdate){
			//currentStretchPercent = newStretchPercent;
			bForceUpdate = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if(!bForceUpdate && targetStretchPercent == currentStretchPercent)
			return;

		float prevStretchPercent = currentStretchPercent;
		float stretchChange = maxStretchSpeed * Time.deltaTime;

		if(bForceUpdate){
			bForceUpdate = false;
			currentStretchPercent = targetStretchPercent;
		}else{
			if(Mathf.Abs(targetStretchPercent - currentStretchPercent) > stretchChange){
				if(targetStretchPercent < currentStretchPercent)
					currentStretchPercent -= stretchChange;
				else
					currentStretchPercent += stretchChange;	
			}else
				currentStretchPercent = targetStretchPercent;
		}
		if(fullTranslate != null)
			fullTranslate.transform.localPosition = stretchDir * stretchDist * currentStretchPercent;

		if(scaledTranslate != null){
			for(int i = 0; i < scaledTranslate.Length; i++){
				scaledTranslate[i].localPosition = (scaledTranslate[i].localPosition - Vector3.Project(scaledTranslate[i].localPosition,stretchDir)) + (Vector3.Project(scaledTranslate[i].localPosition,stretchDir) / ((stretchDist * prevStretchPercent) + 1.0f)) * ((stretchDist * currentStretchPercent) + 1.0f);
			}
		}

		if(xStretch != null){
			xStretch.transform.localScale = new Vector3((stretchDir.x * stretchDist * currentStretchPercent) + 1.0f,1.0f,1.0f);
			
			if(stretchDir.x != 0.0f){
				Renderer[] cr = xStretch.GetComponentsInChildren<Renderer>(); 
				
				foreach(Renderer renderer in cr){
					for(int i = 0; i < renderer.materials.Length; i++){
						Vector2 prevMatScale = renderer.materials[i].GetTextureScale("_MainTex");
						
						if(uvStretchDir.x != 0.0f){
							prevMatScale.x = (prevMatScale.x / ((stretchDist * prevStretchPercent) + 1.0f)) * ((stretchDist * currentStretchPercent) + 1.0f);
						}
						if(uvStretchDir.y != 0.0f){
							prevMatScale.y = (prevMatScale.y / ((stretchDist * prevStretchPercent) + 1.0f)) * ((stretchDist * currentStretchPercent) + 1.0f);
						}
						renderer.materials[i].SetTextureScale("_MainTex", prevMatScale);
					}
				}
			}
		}
		
		if(yStretch != null){
			yStretch.transform.localScale = new Vector3(1.0f,(stretchDir.y * stretchDist * currentStretchPercent) + 1.0f,1.0f);
			
			if(stretchDir.y != 0.0f){
				Renderer[] cr = yStretch.GetComponentsInChildren<Renderer>(); 
				
				foreach(Renderer renderer in cr){
					for(int i = 0; i < renderer.materials.Length; i++){
						Vector2 prevMatScale = renderer.materials[i].GetTextureScale("_MainTex");
						
						if(uvStretchDir.x != 0.0f){
							prevMatScale.x = (prevMatScale.x / ((stretchDist * prevStretchPercent) + 1.0f)) * ((stretchDist * currentStretchPercent) + 1.0f);
						}
						if(uvStretchDir.y != 0.0f){
							prevMatScale.y = (prevMatScale.y / ((stretchDist * prevStretchPercent) + 1.0f)) * ((stretchDist * currentStretchPercent) + 1.0f);
						}
						renderer.materials[i].SetTextureScale("_MainTex", prevMatScale);
					}
				}
			}
		}
		
		if(zStretch != null){
			zStretch.transform.localScale = new Vector3(1.0f,1.0f,(stretchDir.z * stretchDist * currentStretchPercent) + 1.0f);
			
			if(stretchDir.z != 0.0f){
				Renderer[] cr = zStretch.GetComponentsInChildren<Renderer>(); 
				
				foreach(Renderer renderer in cr){
					for(int i = 0; i < renderer.materials.Length; i++){
						Vector2 prevMatScale = renderer.materials[i].GetTextureScale("_MainTex");
						
						if(uvStretchDir.x != 0.0f){
							prevMatScale.x = (prevMatScale.x / ((stretchDist * prevStretchPercent) + 1.0f)) * ((stretchDist * currentStretchPercent) + 1.0f);
						}
						if(uvStretchDir.y != 0.0f){
							prevMatScale.y = (prevMatScale.y / ((stretchDist * prevStretchPercent) + 1.0f)) * ((stretchDist * currentStretchPercent) + 1.0f);
						}
						renderer.materials[i].SetTextureScale("_MainTex", prevMatScale);
					}
				}
			}
		}
	}

}
