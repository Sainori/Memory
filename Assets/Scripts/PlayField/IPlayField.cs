using System;
using System.Collections;
using LightAndCameraSystem;
using RoundSystems.Interfaces;
using UnityEngine;

namespace PlayField
{
    public interface IPlayField
    {
        event Action OnGameEnd;

        IEnumerator Initialize(IMatchSystem matchSystem, Mesh[] cardReferences,
            ILightAndCameraSystem lightAndCameraSystem);
        void DirectUpdate();
        IEnumerator Reset();
    }
}