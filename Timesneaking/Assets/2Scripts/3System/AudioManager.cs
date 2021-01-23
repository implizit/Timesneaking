using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

	public void PlayIfNotPlaying(string sound)
	{
		internalPlay(sound, true);
	}

	public void Play(string sound)
	{
		internalPlay(sound, false);
	}
	private void internalPlay(string sound, bool ifnotplaying)
	{
		Sound s = find(sound);

		if (!ifnotplaying || !s.source.isPlaying)
		{
			s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
			s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

			s.source.Play();
		}
	}
	public void Stop(string sound)
	{
		Sound s = find(sound);

		s.source.Stop();
	}

	private Sound find(string sound)
    {
		Sound result = Array.Find(sounds, item => item.name == sound);
		if (result == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
		}
		return result;
	}
}
