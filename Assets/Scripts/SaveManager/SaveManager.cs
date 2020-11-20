using UnityEngine;

namespace SaveManager
{
    public class SaveManager : MonoBehaviour, ISaveManager
    {
        private const string MaxScorePrefName = "Max Score";

        #region DebugMsg

        private const string LoadMsg = "Loaded max score is {0}";
        private const string TryToUpdateMsg = "Trying to set new max score - {0}";
        private const string NewMaxMsg = "New max score is {0}";

        #endregion

        [SerializeField] private uint maxScore;
        public uint MaxScore => maxScore;

        private void Awake()
        {
            LoadMaxScore();
        }

        private void LoadMaxScore()
        {
            maxScore = (uint) PlayerPrefs.GetInt(MaxScorePrefName);
            Debug.Log(string.Format(LoadMsg, MaxScore));
        }

        public bool TrySaveNewMax(uint score)
        {
            Debug.Log(string.Format(TryToUpdateMsg, score));
            if (score <= MaxScore)
            {
                return false;
            }

            SaveMax(score);
            return true;
        }

        private void SaveMax(uint score)
        {
            maxScore = score;
            PlayerPrefs.SetInt(MaxScorePrefName, (int) score);
            Debug.Log(string.Format(NewMaxMsg, score));
            PlayerPrefs.Save();
        }

#if UNITY_EDITOR
        public void LoadPreviousScore() => LoadMaxScore();

        public void ResetScore()
        {
            SaveMax(0);
        }

        public void UpdateMax()
        {
            SaveMax(maxScore);
        }
#endif
    }
}