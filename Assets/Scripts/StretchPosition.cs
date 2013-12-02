using UnityEngine;
using System.Collections;

public class StretchPosition : MonoBehaviour {

	public GameObject stretchPrefab;
	public Vector3 spawnOffset;
	public float stretchSpeed;

	private GameObject stetchingSegment;
	private Transform xStretch;
	private Transform yStretch;
	private Transform zStretch;

	private bool bWorking;
	private GameObject player;
	private float currentscale;

//	void start(){
//		if(stretchPrefab == null){
//			gameObject.SetActive(false);
//		}else{
//
//		}
//	}
//
//	void OnTriggerEnter(Collider other){
//		if(other.tag == "Player"){
//			if(!bWorking){
//				bWorking = true;
//				currentscale = 0.0f;
//
//				player = other.gameObject;
//				stetchingSegment = Instantiate(stretchPrefab, transform.position + spawnOffset, transform.rotation);
//				
//				xStretch = stetchingSegment.transform.Find("XScalePieces");
//				//xStretch.localScale.x = 0.0f;
//				yStretch = stetchingSegment.transform.Find("YScalePieces");
//				//yStretch.localScale.y = 0.0f;
//				zStretch = stetchingSegment.transform.Find("ZScalePieces");
//				//zStretch.localScale.z = 0.0f;
//			}
//		}
//	}
//
//	void OnTriggerExit(Collider other){
//	}
//
//	void Update(){
//		if(player != null){
//			
//		}
//	}
}
