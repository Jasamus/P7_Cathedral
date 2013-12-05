using UnityEngine;
using System.Collections;
/*
 * This class manages all of the stretching of objects
 * 
 * TODO: change the UV scaling to include
 */
public class StretchV2 : MonoBehaviour {
//	
//	//public Vector3 stretchDir = new Vector3(0.0f,1.0f,0.0f);
//	//public Vector2 uvStretchDir = new Vector2(0.0f, 1.0f);
//	public Vector3 uStretchDir = new Vector3(0.0f,1.0f,0.0f);
//	public float uStretchDist = 20.0f;
//	public float uMaxStretchSpeed = 0.8f;
//
//	private float uCurrentStretchPrecent;
//	private float uTargetStretchPercent;
//	private bool bUForceUpdate;
//
//	public Vector3 vStretchDir = new Vector3(0.0f,0.0f,1.0f);
//	public float vStretchDist = 20.0f;
//	public float vMaxStretchSpeed = 0.8f;
//
//	private float vCurrentStretchPrecent;
//	private float vTargetStretchPercent;
//	private bool bVForceUpdate;
//	
//	private Transform[] xTranslate;
//	private Transform xScale;
//	//private Transform xScaleTranslate;
//
//	private Transform[] yTranslate;
//	private Transform yScale;
//	//private Transform[] yScaleTranslate;
//
//	private Transform[] zTranslate;
//	private Transform zScale;
//	//private Transform[] zScaleTranslate;
//
////	private Transform vTrans;
////	private Transform bothTrans;
////	private Transform uStretch;
////	private Transform vStretch;
////	private Transform bothStretch;
////
////	//public float prevStretchPercent = 0.0f;
////	private float currentStretchPercent;
////	private float targetStretchPercent;
////	private bool bForceUpdate;
//
//	// Use this for initialization
//	void Start () {
//		Transform xWall = transform.Find("xWall");
//		Transform yWall = transform.Find("yWall");
//		Transform zWall = transform.Find("zWall");
//
//		xTranslate = new Transform[xWall.childCount];
//		for(int i = 0; i < xWall.childCount; i++){
//			xTranslate[i] = xWall.GetChild(i);
//		}
//
//		yTranslate = new Transform[yWall.childCount];
//		for(int i = 0; i < yWall.childCount; i++){
//			yTranslate[i] = yWall.GetChild(i);
//		}
//
//		zTranslate = new Transform[zWall.childCount];
//		for(int i = 0; i < zWall.childCount; i++){
//			zTranslate[i] = zWall.GetChild(i);
//		}
//
//		xScale = xWall.Find("xScale");
//		yScale = yWall.Find("yScale");
//		zScale = zWall.Find("zScale");
//	}
//
//	//StretchIndex
//	//0 = u direction
//	//1 = v direction
//	public void UpdateStretch(float stretchIndex, float newStretchPercent, bool bImmediateUpdate = false){
//		if(stretchIndex == 0){
//			uTargetStretchPercent = newStretchPercent;
//
//			if(bImmediateUpdate)
//				bUForceUpdate = true;
//		}else if(stretchIndex == 1){
//			vTargetStretchPercent = newStretchPercent;
//
//			if(bImmediateUpdate)
//				bVForceUpdate = true;
//		}else{
//			Debug.LogWarning("Stretch index " + stretchIndex + "is out of bounds.");
//		}
//	}
//
//	// Update is called once per frame
//	void Update () {
//		if(bUForceUpdate || uTargetStretchPercent != uCurrentStretchPrecent){
//			float uPrevStretchPercent = uCurrentStretchPrecent;
//			float stretchChange = uMaxStretchSpeed * Time.deltaTime;
//
//			if(bUForceUpdate){
//				bUForceUpdate = false;
//				uCurrentStretchPrecent = uTargetStretchPercent;
//			}else{
//				if(Mathf.Abs(uTargetStretchPercent - uCurrentStretchPrecent) > stretchChange){
//					if(uTargetStretchPercent < uCurrentStretchPrecent)
//						uCurrentStretchPrecent -= stretchChange;
//					else
//						uCurrentStretchPrecent += stretchChange;	
//				}else
//					uCurrentStretchPrecent = uTargetStretchPercent;
//			}
//
//			Vector3 zStretch = Vector3.forward * Vector3.Dot(uStretchDir, Vector3.forward);
//			if(zStretch != Vector3.zero){
//				for(int i = 0; i < zTranslate.Length; i++){
//					zTranslate[i].position = (zStretch / ((uMaxStretchSpeed * uPrevStretchPercent) + 1.0f)) * ((uMaxStretchSpeed * uCurrentStretchPrecent) + 1.0f);
//				}
//			}
//			Vector3 yStretch = Vector3.up * Vector3.Dot(uStretchDir, Vector3.up);
//			if(yStretch != Vector3.zero){
//				for(int i = 0; i < yTranslate.Length; i++){
//					yTranslate[i].position = (yStretch / ((uMaxStretchSpeed * uPrevStretchPercent) + 1.0f)) * ((uMaxStretchSpeed * uCurrentStretchPrecent) + 1.0f);
//				}
//			}
//			Vector3 xStretch = Vector3.left * Vector3.Dot(uStretchDir, Vector3.left);
//			if(xStretch != Vector3.zero){
//				for(int i = 0; i < xTranslate.Length; i++){
//					xTranslate[i].position = (xStretch / ((uMaxStretchSpeed * uPrevStretchPercent) + 1.0f)) * ((uMaxStretchSpeed * uCurrentStretchPrecent) + 1.0f);
//				}
//			}
//		}
//
//		if(bVForceUpdate || vTargetStretchPercent != vCurrentStretchPrecent){
//			float vPrevStretchPercent = vCurrentStretchPrecent;
//			float stretchChange = uMaxStretchSpeed * Time.deltaTime;
//			
//			if(bVForceUpdate){
//				bVForceUpdate = false;
//				vCurrentStretchPrecent = vTargetStretchPercent;
//			}else{
//				if(Mathf.Abs(vTargetStretchPercent - vCurrentStretchPrecent) > stretchChange){
//					if(vTargetStretchPercent < vCurrentStretchPrecent)
//						vCurrentStretchPrecent -= stretchChange;
//					else
//						vCurrentStretchPrecent += stretchChange;	
//				}else
//					vCurrentStretchPrecent = vTargetStretchPercent;
//			}
//			Vector3 zStretch = Vector3.forward * Vector3.Dot(vStretchDir, Vector3.forward);
//			if(zStretch != Vector3.zero){
//				for(int i = 0; i < zTranslate.Length; i++){
//					zTranslate[i].position = (zStretch / ((vMaxStretchSpeed * vPrevStretchPercent) + 1.0f)) * ((vMaxStretchSpeed * vCurrentStretchPrecent) + 1.0f);
//				}
//			}
//			Vector3 yStretch = Vector3.up * Vector3.Dot(vStretchDir, Vector3.up);
//			if(yStretch != Vector3.zero){
//				for(int i = 0; i < yTranslate.Length; i++){
//					yTranslate[i].position = (yStretch / ((vMaxStretchSpeed * vPrevStretchPercent) + 1.0f)) * ((vMaxStretchSpeed * vCurrentStretchPrecent) + 1.0f);
//				}
//			}
//			Vector3 xStretch = Vector3.left * Vector3.Dot(vStretchDir, Vector3.left);
//			if(xStretch != Vector3.zero){
//				for(int i = 0; i < xTranslate.Length; i++){
//					xTranslate[i].position = (xStretch / ((vMaxStretchSpeed * vPrevStretchPercent) + 1.0f)) * ((vMaxStretchSpeed * vCurrentStretchPrecent) + 1.0f);
//				}
//			}
//
//		}
////		if(!bForceUpdate && targetStretchPercent == currentStretchPercent)
////			return;
////
////		float prevStretchPercent = currentStretchPercent;
////		float stretchChange = maxStretchSpeed * Time.deltaTime;
////
////		if(bForceUpdate){
////			bForceUpdate = false;
////			currentStretchPercent = targetStretchPercent;
////		}else{
////			if(Mathf.Abs(targetStretchPercent - currentStretchPercent) > stretchChange){
////				if(targetStretchPercent < currentStretchPercent)
////					currentStretchPercent -= stretchChange;
////				else
////					currentStretchPercent += stretchChange;	
////			}else
////				currentStretchPercent = targetStretchPercent;
////		}
////
////		staticStretch.transform.localPosition = stretchDir * stretchDist * currentStretchPercent;
////		
////		if(xStretch != null){
////			xStretch.transform.localScale = new Vector3((stretchDir.x * stretchDist * currentStretchPercent) + 1.0f,1.0f,1.0f);
////			
////			if(stretchDir.x != 0.0f){
////				Renderer[] cr = xStretch.GetComponentsInChildren<Renderer>(); 
////				
////				foreach(Renderer renderer in cr){
////					for(int i = 0; i < renderer.materials.Length; i++){
////						Vector2 prevMatScale = renderer.materials[i].GetTextureScale("_MainTex");
////						
////						if(uvStretchDir.x != 0.0f){
////							prevMatScale.x = (prevMatScale.x / ((stretchDist * prevStretchPercent) + 1.0f)) * ((stretchDist * currentStretchPercent) + 1.0f);
////						}
////						if(uvStretchDir.y != 0.0f){
////							prevMatScale.y = (prevMatScale.y / ((stretchDist * prevStretchPercent) + 1.0f)) * ((stretchDist * currentStretchPercent) + 1.0f);
////						}
////						renderer.materials[i].SetTextureScale("_MainTex", prevMatScale);
////					}
////				}
////			}
////		}
////		
////		if(yStretch != null){
////			yStretch.transform.localScale = new Vector3(1.0f,(stretchDir.y * stretchDist * currentStretchPercent) + 1.0f,1.0f);
////			
////			if(stretchDir.y != 0.0f){
////				Renderer[] cr = yStretch.GetComponentsInChildren<Renderer>(); 
////				
////				foreach(Renderer renderer in cr){
////					for(int i = 0; i < renderer.materials.Length; i++){
////						Vector2 prevMatScale = renderer.materials[i].GetTextureScale("_MainTex");
////						
////						if(uvStretchDir.x != 0.0f){
////							prevMatScale.x = (prevMatScale.x / ((stretchDist * prevStretchPercent) + 1.0f)) * ((stretchDist * currentStretchPercent) + 1.0f);
////						}
////						if(uvStretchDir.y != 0.0f){
////							prevMatScale.y = (prevMatScale.y / ((stretchDist * prevStretchPercent) + 1.0f)) * ((stretchDist * currentStretchPercent) + 1.0f);
////						}
////						renderer.materials[i].SetTextureScale("_MainTex", prevMatScale);
////					}
////				}
////			}
////		}
////		
////		if(zStretch != null){
////			zStretch.transform.localScale = new Vector3(1.0f,1.0f,(stretchDir.z * stretchDist * currentStretchPercent) + 1.0f);
////			
////			if(stretchDir.z != 0.0f){
////				Renderer[] cr = zStretch.GetComponentsInChildren<Renderer>(); 
////				
////				foreach(Renderer renderer in cr){
////					for(int i = 0; i < renderer.materials.Length; i++){
////						Vector2 prevMatScale = renderer.materials[i].GetTextureScale("_MainTex");
////						
////						if(uvStretchDir.x != 0.0f){
////							prevMatScale.x = (prevMatScale.x / ((stretchDist * prevStretchPercent) + 1.0f)) * ((stretchDist * currentStretchPercent) + 1.0f);
////						}
////						if(uvStretchDir.y != 0.0f){
////							prevMatScale.y = (prevMatScale.y / ((stretchDist * prevStretchPercent) + 1.0f)) * ((stretchDist * currentStretchPercent) + 1.0f);
////						}
////						renderer.materials[i].SetTextureScale("_MainTex", prevMatScale);
////					}
////				}
////			}
////		}
//	}

}
