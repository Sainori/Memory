using SaveManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _currentTime = 0;
    private ISaveManager _saveManager;

    private void Awake()
    {
        _saveManager = GetComponent<ISaveManager>();
    }

    void FixedUpdate()
    {
        if (_currentTime < 3)
        {
            _currentTime += Time.deltaTime;
            return;
        }

        _currentTime = 0;
        var score = Random.Range(100, 200);
        _saveManager.TrySaveNewMax(score);
    }
}
