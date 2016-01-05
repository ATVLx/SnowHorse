using UnityEngine;
using System.Collections;

public class bgMaterialView : MonoBehaviour {

	private float scrollSpeed = 0.01f;
	private Renderer rend;

	void Start() {
		
		rend = GetComponent<Renderer>();
	}

	void Update() {
		
		float offset = Time.time * scrollSpeed;
		rend.material.mainTextureOffset = new Vector2(offset, offset);
	
	}
}
