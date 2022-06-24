using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class House : MonoBehaviour
{
    private static WaitForSeconds _waitAlarmSoundGain = new WaitForSeconds(0.04f);

    [SerializeField] private Alarm _alarm;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnThiefInsideHouse()
    {
        _animator.SetBool(HouseAnimatorController.Params.IsThiefInsideHouse, true);
        _alarm.TurnOn();
    }

    public void OnThiefOutsideHouse()
    {
        _animator.SetBool(HouseAnimatorController.Params.IsThiefInsideHouse, false);
        _alarm.TurnOff();
    }
}
