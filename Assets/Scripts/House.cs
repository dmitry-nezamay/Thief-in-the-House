using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class House : MonoBehaviour
{
    private static WaitForSeconds _waitAlarmSoundGain = new WaitForSeconds(0.04f);

    [SerializeField] private AlarmSystem _alarmSystem;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnThiefInsideHouse()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        _animator.SetBool(HouseAnimatorController.Params.IsThiefInsideHouse, true);
        _alarmSystem.StartAlarm();
    }

    public void OnThiefOutsideHouse()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        _animator.SetBool(HouseAnimatorController.Params.IsThiefInsideHouse, false);
        _alarmSystem.StopAlarm();
    }
}
