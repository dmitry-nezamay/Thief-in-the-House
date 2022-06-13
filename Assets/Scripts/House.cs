using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private static WaitForSeconds _waitAlarmSoundGain = new WaitForSeconds(0.04f);

    private Animator _animator;
    private AudioSource _audioSource;
    private Coroutine _alarmSoundCoroutine;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnThiefInsideHouse()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        _animator.SetBool("IsThiefInsideHouse", true);
        _audioSource.Play();
        _alarmSoundCoroutine = StartCoroutine(AlarmSoundGain());
    }

    public void OnThiefOutsideHouse()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        _animator.SetBool("IsThiefInsideHouse", false);
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
