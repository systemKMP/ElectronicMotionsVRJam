using UnityEngine;
using System.Collections;

public class simpleCamScript : MonoBehaviour {
	Camera internalCamera;
	
	public Material postProcessingMaterial;
	private Material instancedMaterial;

	// Use this for initialization
	void Start () {
		
		instancedMaterial = Instantiate(postProcessingMaterial) as Material;
		
		//instancedMaterial.SetTexture("colorLUT", LUT);
		//instancedMaterial.SetTexture("colorFlashLUT", colorFlashLUT);
		//instancedMaterial.SetTexture("crashLUT", crashLUT);
		//instancedMaterial.SetTexture("turboLUT", turboLUT);
		
		// shader compiler crashed when trying to compute these values outside of the function...
		//var scale = (LUTSource.height - 1.0f) / (LUTSource.height);
		//var offset =  0.5f / LUTSource.height;
		//instancedMaterial.SetFloat("lutScale", scale);
		//instancedMaterial.SetFloat("lutOffset", offset);
		internalCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnRenderImage(RenderTexture src, RenderTexture dest) {
		
		
	
			var screenRatio = (float)internalCamera.pixelWidth / (float)internalCamera.pixelHeight;
			instancedMaterial.SetFloat ("screenRatio", screenRatio);
			instancedMaterial.SetFloat ("random", Random.value);
			//Debug.LogWarning("Blit src:" + src.width + "x" + src.height + " Screen:" + Screen.width + "x" + Screen.height);// + " dest:" + dest.width + "x" + dest.height);
			Graphics.Blit (src, dest, instancedMaterial);

	}
}
