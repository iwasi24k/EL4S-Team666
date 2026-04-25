using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class SlotData : MonoBehaviour
{
    public enum SlotSymbol
    {
        Chara_Speed = 0,
        Chara_Scale,
        Bullet_Speed,
        Bullet_Scale,
        Alpha,
    }
     public enum SlotTarget
    {
        Player = 0,
        Enemy,
        Field,
    }

    [Header("効果対象の出目")]
    [SerializeField] public List<SlotTarget> SlotTargets;

    [Header("効果内容の出目")]
    [SerializeField] public List<SlotSymbol> SlotSymbols;

    [Header("パラメータの倍率の出目")]
    [SerializeField]public List<float> ParameterMult;    // パラメータの倍率



}
