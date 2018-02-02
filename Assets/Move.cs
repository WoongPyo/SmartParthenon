using UnityEngine;

public class Move : MonoBehaviour {
    public float speed = 5.0f;
    public DirPad dirPad;

    void Start () {
        Debug.Log("Start() called.");
	}
	void Update () {
        //Debug.LogFormat("Time.deltaTime = {0}", Time.deltaTime);
        if (dirPad.dragging) {
            var dn = dirPad.dir.normalized * Time.deltaTime * speed;
            transform.Translate(new Vector3(dn.x, 0, dn.y));
        }
        else {
            var dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            var dz = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            transform.Translate(new Vector3(dx, 0, dz));
        }
	}
    private void OnTriggerEnter(Collider other) {
        Debug.LogFormat("OnTroggerEnter called. other is {0}", other.name);
    }
    private void OnTriggerExit(Collider other) {
        Debug.LogFormat("OnTroggerExit called. other is {0}", other.name);
    }
}
