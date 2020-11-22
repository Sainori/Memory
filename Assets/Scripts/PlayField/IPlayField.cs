using System;
using System.Collections;
using RoundSystems.Interfaces;
using UnityEngine;

namespace PlayField
{
    public interface IPlayField
    {
        event Action OnGameEnd;

        IEnumerator Initialize(IMatchSystem matchSystem, Mesh[] cardReferences);
        void DirectUpdate();
        IEnumerator Reset();
    }
}