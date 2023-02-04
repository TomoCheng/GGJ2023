using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour
{
	public void SetClip(AudioClip iClip)
	{
		AudioSource.clip = iClip;
		AudioSource.Play();
		WaitAudioPlay().Forget();
	}
	private async UniTask WaitAudioPlay()
	{
		await UniTask.WaitWhile(() => AudioSource.isPlaying);
		Destroy(this.gameObject);
	}
	public AudioSource AudioSource;
}
