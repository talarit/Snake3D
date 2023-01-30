using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Settings",fileName= "Settings")]
public class Settings : ScriptableObject
{
    //настройки
    private static Settings _i;
   [SerializeField] private MovementData _movementData;
   [SerializeField] private CameraPosData _cameraPosData;

    public static Settings I => _i == null ? LoadData() : _i;

    public MovementData MovementData => _movementData;

    public CameraPosData CameraPosData => _cameraPosData;

    private static Settings LoadData()
    {
        return _i = Resources.Load<Settings>("Settings");
    }
}
