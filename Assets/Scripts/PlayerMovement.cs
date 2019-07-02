using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
	public Rigidbody rb;
	public Text speedText;

	public float forwardForce = 20000f;
	public float sidewaysForce = 120;


	// Update is called once per frame; Fixed because physics
	void FixedUpdate()
	{
		rb.AddForce(0f, 0f, forwardForce * TimeMultiplier());

		if (Input.GetKey("d"))
		{
			rb.AddForce(sidewaysForce * TimeMultiplier(), 0f, 0f, ForceMode.VelocityChange);
		}

		if (Input.GetKey("a"))
		{
			rb.AddForce(-sidewaysForce * TimeMultiplier(), 0f, 0f, ForceMode.VelocityChange);
		}

		if (rb.position.y < -1f)
		{
			FindObjectOfType<GameManager>().EndGame(0);
		}
	}

	private float TimeMultiplier()
	{
		float a = 0.008f * Time.timeSinceLevelLoad + 1f;
		float b = 0.0002f * ((SceneManager.GetActiveScene().buildIndex) / 3) * Mathf.Pow(Time.timeSinceLevelLoad, 2) + 1f;
		float c = 1f + (SceneManager.GetActiveScene().buildIndex / 6f);

		return a * b * c * Time.deltaTime;
	}
}
