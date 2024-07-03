using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private ParticleSystem _finishEffect;

    private readonly float _sceneReloadDelay = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player"))
        {
           GetComponent<AudioSource>().Play();
            _finishEffect.Play();
            Invoke(nameof(ReloadTheScene), _sceneReloadDelay);
        }
    }

    private void ReloadTheScene()
    {
        SceneManager.LoadScene(0);
    }
}
