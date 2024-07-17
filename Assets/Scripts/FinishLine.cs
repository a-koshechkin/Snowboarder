using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    #region Fields
    [SerializeField] private ParticleSystem _finishEffect;

    private readonly float _sceneReloadDelay = 3f;

    #endregion Fields

    #region MonoBehaviour

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player"))
        {
           GetComponent<AudioSource>().Play();
            _finishEffect.Play();
            Invoke(nameof(LevelSuccess), _sceneReloadDelay);
        }
    }

    #endregion MonoBehaviour

    #region Methods

    private void LevelSuccess()
    {
        SceneManager.LoadScene(0);
    }

    #endregion Methods
}
