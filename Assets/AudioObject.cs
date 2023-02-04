using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
		iTokenSource = new CancellationTokenSource();
		WaitAudioPlay(iTokenSource.Token).Forget();
	}
	private void OnDestroy()
	{
		iTokenSource.Cancel();
	}
	private async UniTask WaitAudioPlay(CancellationToken iToken = default)
	{
		while (AudioSource.isPlaying)
		{
			await UniTask.Delay(1, false, 0, iToken);
		}
		Destroy(this.gameObject);
	}
	public AudioSource AudioSource;

	private CancellationTokenSource iTokenSource;
}
