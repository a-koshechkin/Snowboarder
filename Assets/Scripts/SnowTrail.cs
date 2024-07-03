using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem _trail;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _trail.Play();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _trail.Stop();
    }
}
