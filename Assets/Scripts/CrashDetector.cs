using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private ParticleSystem _crashEffect;
    private readonly float _sceneReloadDelay = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Ground"))
        {
            FindObjectOfType<PlayerController>().CantMove();
            var audioSource = GetComponent<AudioSource>();
            audioSource.time = 1.4f;
            audioSource.Play();
            _crashEffect.Play();
            Invoke(nameof(ReloadTheScene), _sceneReloadDelay);
        }
    }

    private void ReloadTheScene()
    {
        SceneManager.LoadScene(0);
    }
}
