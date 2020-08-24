using UnityEngine;
using UnityEngine.SceneManagement;

public class SuodyWoody : MonoBehaviour

{
   private Vector3 _initialPosition;
   private bool _birdWasLaunched;
   private float _timeSittingAround;

    [SerializeField] private float _launchPower = 500;

private void Awake()
{
    _initialPosition = transform.position;
}
   private void OnMouseDrag()
   {
       Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       transform.position = new Vector3(newPosition.x, newPosition.y);
   }
private void OnMouseUp()
{
    Vector2 directionToInitialPosition = _initialPosition - transform.position; 
    GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition*_launchPower);
    GetComponent<Rigidbody2D>().gravityScale = 1;
    _birdWasLaunched = true;

    GetComponent<LineRenderer>().enabled = false;
}

private void OnMouseDown()
{
GetComponent<LineRenderer>().enabled = true;
}
private void Update()
{
    if (_birdWasLaunched &&
    GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
    {
         _timeSittingAround += Time.deltaTime;
    }

    if (transform.position.y > 20 ||
    transform.position.y < -20 ||
    transform.position.x > 20 ||
    transform.position.x < -20 ||
    _timeSittingAround > 2) 
    {
     string currentSceneName = SceneManager.GetActiveScene().name;
      SceneManager.LoadScene(currentSceneName);
    }

    GetComponent<LineRenderer>().SetPosition(0, transform.position);
    GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
}





}

