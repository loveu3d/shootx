using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource sound;
	// Use this for initialization
	void Start () {

	}

	public void Play(string str)
	{
		AudioClip clip =(AudioClip)Resources.Load("Sound/"+str, typeof(AudioClip));//调用Resources方法加载AudioClip资源
		PlayAudioClip(clip);
	}
	public void PlayAudioClip(AudioClip clip)
	{
		GameObject gameObject = GameObject.Find("Main Camera");

		if (clip== null)
			return;
		AudioSource source = (AudioSource)gameObject.GetComponent("AudioSource");
		if (source == null)
			source =(AudioSource)gameObject.AddComponent<AudioSource>();
		source.clip = clip;
//		source.minDistance= 1.0f;
//		source.maxDistance= 50;
//		source.rolloffMode= AudioRolloffMode.Linear;
//		source.transform.position =transform.position;
		source.Play();
	}

	// Update is called once per frame
	void Update () {

	}
	public void PlayBiu()
	{
		Play("biu");
	}

	public void PlayBg1()
	{
	
	}

}
