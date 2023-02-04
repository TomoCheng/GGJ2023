using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour
{
	private void Awake()
	{
		transform.parent = GameObject.Find("Audio").transform;
	}
	public void SetClip(AudioClip iClip)
	{
		AudioSource.clip = iClip;
		AudioSource.Play();
		WaitAudioPlay().Forget();
	}
	private void OnDestroy()
	{
		IsDestroy = true;
	}
	private async UniTask WaitAudioPlay()
	{
		while (AudioSource.isPlaying)
		{
			await UniTask.Yield();
		}
		Destroy(this.gameObject);
	}
	public AudioSource AudioSource;
	public bool IsDestroy;
}
