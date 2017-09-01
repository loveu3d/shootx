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
		AudioClip clip =(AudioClip)Resources.Load("Sound/"+"bgm", typeof(AudioClip));//调用Resources方法加载AudioClip资源
//		bgm
		bgm.clip = clip;
		bgm.loop=true;
		bgm.Play();
	}
	public void Play(string str)
	{
		AudioClip clip =(AudioClip)Resources.Load("Sound/"+str, typeof(AudioClip));//调用Resources方法加载AudioClip资源
		PlayAudioClip(clip);
	}
	public void PlayAudioClip(AudioClip clip)
	{
		sound.clip = clip;
//		source.minDistance= 1.0f;
//		source.maxDistance= 50;
//		source.rolloffMode= AudioRolloffMode.Linear;
//		source.transform.position =transform.position;
		sound.Play();
	}

	// Update is called once per frame
	void Update () {

	}
	public void PlaySound(string str)
	{
		Play(str);
	}
	public void PlayWin()
	{
		StartCoroutine(Play_Win());
	}
	 IEnumerator Play_Win()
	{
		//		
		yield return new WaitForSeconds(0.5f);
		Debug.Log("WaitForSeconds");
		PlaySound("win");
	}
	public void PlayBg1()
	{
	
	}

}
