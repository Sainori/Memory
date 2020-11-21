using UnityEngine;

namespace Card
{
    public class CardReferences : MonoBehaviour
    {
        [SerializeField] private GameObject[] cardMeshes;

        public GameObject[] GetCardObjects()
        {
            return cardMeshes;
        }

    }
}