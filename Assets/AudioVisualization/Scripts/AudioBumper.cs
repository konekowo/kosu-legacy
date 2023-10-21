using UnityEngine;

public class AudioBumper : MonoBehaviour
{
    public AudioPeer audioPeer;
    public int frequencyBand = 0;
    public float multiplier = 0.2f;
    public Vector3 bumpDimensions = new(0, 1, 0);

    private Vector3 baseScale;
    private Material material;

    private void Start()
    {
        baseScale = transform.localScale;
        //material = transform.GetChild(0).GetComponent<MeshRenderer>().materials[0];
    }

    private void Update()
    {
        if (audioPeer == null) return;


        transform.localScale = baseScale + bumpDimensions * audioPeer.GetFrequencyBand(frequencyBand) * multiplier;


        var audioBand = audioPeer.GetFrequencyBand(frequencyBand);
        var color = new Color(audioBand * 0.5f, audioBand * 0.4f, audioBand);
        //material.SetColor("_EmissionColor", color);
    }
}