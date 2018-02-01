using UnityEngine;

public class Move : MonoBehaviour {
	void Start () {
        Debug.Log("Start() called.");
	}
	void Update () {
        var dx = Input.GetAxis("Horizontal");
        var dz = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(dx, 0, dz));
	}
    private void OnTriggerEnter(Collider other) {
        Debug.LogFormat("OnTroggerEnter called. other is {0}", other.name);
    }
    private void OnTriggerExit(Collider other) {
        Debug.LogFormat("OnTroggerExit called. other is {0}", other.name);
    }
}
