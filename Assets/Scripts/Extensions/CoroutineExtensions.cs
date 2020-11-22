using System.Collections;
using System.Linq;
using UnityEngine;

namespace Extensions
{
    public static class CoroutineExtensions
    {
        public static IEnumerator WaitAllCoroutines(this MonoBehaviour mono, params IEnumerator[] coroutines)
        {
            return coroutines.Select(mono.StartCoroutine).ToArray().GetEnumerator();
        }
    }
}