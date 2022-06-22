using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private static WaitForSeconds _waitAlarmSoundGain = new WaitForSeconds(0.04f);

    private AudioSource _audioSource;
    private Coroutine _alarmSoundCoroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        StopAlarm();
    }

    public void StartAlarm()
    {
        _audioSource.Play();
        _alarmSoundCoroutine = StartCoroutine(AlarmSoundGain());
    }

    public void StopAlarm()
    {
        _audioSource.Stop();

        if (_alarmSoundCoroutine != null)
            StopCoroutine(_alarmSoundCoroutine);
    }

    private IEnumerator AlarmSoundGain()
    {
        for (int i = 0; i < 100; i++)
        {
            _audioSource.volume = (float)i / 100;
            yield return _waitAlarmSoundGain;
        }
    }
}