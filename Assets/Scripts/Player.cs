using UnityEngine;

public class Player : MonoBehaviour
{
    private Health health;

    private ControllerUI controllerUI;

    private bool isPlaying = true;

    private void Start()
    {
        health = GetComponent<Health>();
        controllerUI = GetComponent<ControllerUI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.CompareTag("Enemy") && isPlaying)
        {
            health.TakeDamage(1);
            Vector3 pushDirection = (transform.position - collision.transform.position) .normalized;
            transform.position += pushDirection * 0.5f;
        }

        else if(collision.gameObject.CompareTag("Key"))
        {
            isPlaying = false;
            controllerUI.ShowBulletsUI(true);
        }
    }

    public void Die()
    {
        controllerUI.ShowGameOverUI(true);
    }
}
