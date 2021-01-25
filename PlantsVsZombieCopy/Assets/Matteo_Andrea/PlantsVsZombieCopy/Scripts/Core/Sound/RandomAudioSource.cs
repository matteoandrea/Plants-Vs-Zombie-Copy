using UnityEngine;
using System.Collections.Generic;

public class RandomAudioSource : MonoBehaviour
{
	[SerializeField] private AudioSource _Source;

	[SerializeField]private bool playOnEnabled;

	[SerializeField] private List<AudioClip> clips = new List<AudioClip>();

	

	private void OnEnable()
	{		
		if (playOnEnabled)
		{
			PlayRandomClip();
		}
	}

	
	public void PlayRandomClip()
	{
		_Source.clip = clips[Random.Range(0, clips.Count)];
		_Source.Play();
	}	
}
