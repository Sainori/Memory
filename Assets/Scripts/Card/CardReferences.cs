using System.Linq;
using UnityEngine;

namespace Card
{
    public class CardReferences : MonoBehaviour
    {
        [SerializeField] private GameObject[] cardObjects;

        public Mesh[] GetCardObjects()
        {
            return cardObjects.Select(cardObject => cardObject.GetComponent<MeshFilter>()?.sharedMesh).ToArray();
        }

    }
}