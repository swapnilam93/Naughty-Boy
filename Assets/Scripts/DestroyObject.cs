using System.Collections;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

	public GameObject explosion;
	public AudioClip explode;

    private AudioSource source;

    void Awake () {
    	source = GetComponent<AudioSource>();
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    void DestroyScriptInstance()
    {
        // Removes this script instance from the game object
        Destroy(this);
    }

    void DestroyComponent()
    {
        // Removes the rigidbody from the game object
        Destroy(GetComponent<Rigidbody>());
    }

    void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(gameObject, 5);
    }

    // When the user presses Ctrl, it will remove the
    // BoxCollider component from the game object
    void Update()
    {

    }

	void OnCollisionStay (Collision collision)
    {
		//if player presses Return of left mouse button destroy object
		foreach (ContactPoint contact in collision.contacts) {
			if(contact.otherCollider.name == "Player"){
				if (Input.GetKey(KeyCode.Return) || Input.GetMouseButtonDown(0))
				{
                    source.PlayOneShot(explode, 0.7f);
                    StartCoroutine(DestroyAll());
					SimpleCharacterControl.destroyCount++;
				}
			}
		}
	}
    IEnumerator DestroyAll()
    {
        yield return new WaitForSeconds(.5f);
        Instantiate(explosion, transform.position, transform.rotation);
        DestroyGameObject();
    }
}