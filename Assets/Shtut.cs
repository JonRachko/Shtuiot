using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shtut : MonoBehaviour {

    public Vector3 startingPoint;

    private Color[] colors;
    private Material material;
    private Color transition;
    private int pos;
    private IEnumerator backg;

	// Use this for initialization
	void Start () {
        backg = background();
        transition = new Color();
        colors = new Color[] { Color.blue, Color.cyan, Color.green, Color.yellow, Color.red, Color.magenta };
        Material material = gameObject.GetComponent<Renderer>().material;
        Debug.Log(material);
        Debug.Log(material.mainTextureOffset);
        material.mainTextureScale = new Vector2(1f,0.1f);
        startingPoint = Camera.main.transform.position;
        gameObject.GetComponent<Renderer>().material.color = colors[0];
        pos = 0;
        StartCoroutine(backg);

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float y = Time.deltaTime * 0.01f;
        gameObject.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0,y);
    }
    private IEnumerator background()
    {
        yield return new WaitForSeconds(0.1f);

        gameObject.GetComponent<Renderer>().material.color = colors[pos + 1];
        pos++;
        if (pos == 5)
            pos = 0;
        Debug.Log(pos);
        Debug.Log(backg);
        StartCoroutine(background());
    }
}
