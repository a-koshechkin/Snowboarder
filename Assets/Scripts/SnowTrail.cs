using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    #region Fields

    [SerializeField] private ParticleSystem _trail;

    #endregion Fields

    #region MonoBehaviour

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _trail.Play();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _trail.Stop();
    }

    #endregion MonoBehaviour
}
