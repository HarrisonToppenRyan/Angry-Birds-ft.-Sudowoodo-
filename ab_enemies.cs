using UnityEngine;

public class SuodyWoodypt3 : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SuodyWoody bird = collision.collider.GetComponent<SuodyWoody>();
        if (bird != null)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return; 
        }

        SuodyWoodypt3 enemy = collision.collider.GetComponent<SuodyWoodypt3>();
        if (enemy != null)
        {
            return; 
        }

        if (collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}