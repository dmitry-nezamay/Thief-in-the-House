using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private static WaitForSeconds _waitSoundGain = new WaitForSeconds(0.04f);
    private static float _volumeRate = 0.03f;

    private AudioSource _audioSource;
    private Coroutine _soundCoroutine;
    private bool _isVolumeIncreasing;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        TurnOff();
    }

    public void TurnOn()
    {
        _audioSource.volume = 0;
        _isVolumeIncreasing = true;
        _audioSource.Play();
        _soundCoroutine = StartCoroutine(SoundGain());
    }

    public void TurnOff()
    {
        _audioSource.Stop();

        if (_soundCoroutine != null)
            StopCoroutine(_soundCoroutine);
    }

    private IEnumerator SoundGain()
    {
        bool isPlaying = true;

        while (isPlaying)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _isVolumeIncreasing ? 1 : 0, _volumeRate);

            if (_audioSource.volume >= 1)
                _isVolumeIncreasing = false;
            else if (_audioSource.volume <= 0)
                _isVolumeIncreasing = true;

            yield return _waitSoundGain;
        }
    }
}