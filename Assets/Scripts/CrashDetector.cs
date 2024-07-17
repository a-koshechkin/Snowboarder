using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    #region Fields
    [SerializeField] private ParticleSystem _crashEffect;

    private readonly float _sceneReloadDelay = 0.5f;
    private readonly float _audioStartDelay = 1.4f;
    #endregion Fields

    #region MonoBehaviour

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Ground"))
        {
            FindObjectOfType<PlayerController>().DisableControls();
            PlayAudio();
            _crashEffect.Play();
            Invoke(nameof(LevelFailed), _sceneReloadDelay);
        }
    }

    #endregion

    #region Methods

    private void LevelFailed()
    {
        SceneManager.LoadScene(0);
    }

    private void PlayAudio()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.time = _audioStartDelay;
        audioSource.Play();
    }

    #endregion
}
