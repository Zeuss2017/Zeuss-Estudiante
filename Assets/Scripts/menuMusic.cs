using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMusic : MonoBehaviour {

	static bool AudioBegin = false; 
	public AudioClip sonido;
	public AudioSource audioSource;


	void Awake()
	{
		audioSource.loop = true;
		audioSource.clip = sonido;
		audioSource.volume = 0.3f;
		if (!AudioBegin) {
			audioSource.Play ();
			DontDestroyOnLoad (gameObject);
			AudioBegin = true;
		} 
	}
	void Update () {
		if(Application.loadedLevelName == "ActividadSaltoComida" || Application.loadedLevelName == "ActividadSaltoPiratas" ||Application.loadedLevelName == "GlobosComida" ||Application.loadedLevelName == "GlobosPiratas" ||Application.loadedLevelName == "ShooterComida" ||Application.loadedLevelName == "ShooterPiratas")
		{
			audioSource.Stop();
			AudioBegin = false;
		}
	}
}
