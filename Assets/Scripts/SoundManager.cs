using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource sound;
	public AudioSource bgm;

	// Use this for initialization
	void Start () {

	}
	public void PlayBGM(string str)
	{
		AudioClip clip =(AudioClip)Resources.Load("Sound/"+str, typeof(AudioClip));//调用Resources方法加载AudioClip资源
//		bgm
		bgm.clip = clip;
		bgm.loop=true;
		bgm.Play();
	}

	void Update () {

	}
	public void PlaySound(string str)
	{
		PlaySound(str,0);
	}
	public void PlaySound(string str,float delay)
	{
		if(delay==0)
		{
			AudioClip clip =(AudioClip)Resources.Load("Sound/"+str, typeof(AudioClip));//调用Resources方法加载AudioClip资源
			sound.clip = clip;
			//		source.minDistance= 1.0f;
			//		source.maxDistance= 50;
			//		source.rolloffMode= AudioRolloffMode.Linear;
			//		source.transform.position =transform.position;
			sound.Play();
		}else{
			StartCoroutine((PlayDelay(str,delay)));
		}
	
	}
//	public void PlayWin()
//	{
//		StartCoroutine(Play_Win());
//	}
	IEnumerator PlayDelay(string str, float delay)
	{
		//		
		yield return new WaitForSeconds(delay);
//		Debug.Log("WaitForSeconds");
		PlaySound("win",0);
	}

}
