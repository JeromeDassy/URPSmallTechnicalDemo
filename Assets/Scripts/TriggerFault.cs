using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class TriggerFault : MonoBehaviour
{
    public GameObject DieselPunkView;
    public GameObject DieselPunkFault;
    public GameObject MedievalFault;
    public Color DieselPunkFogColor;
    public Volume Volume;
    private ChromaticAberration _ChromaticAberration;
    private LensDistortion _LensDistortion;

    private bool _isDieselPunk = false;

    private Coroutine _CoroutineIn;
    private Coroutine _CoroutineOut;


    // Start is called before the first frame update
    void Start()
    {
        Volume.profile.TryGet(out _ChromaticAberration);
        Volume.profile.TryGet(out _LensDistortion);

        RenderSettings.fogColor = Color.white;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _isDieselPunk = !_isDieselPunk;

            DieselPunkView.SetActive(_isDieselPunk);
            MedievalFault.SetActive(_isDieselPunk);
            DieselPunkFault.SetActive(!_isDieselPunk);
            RenderSettings.fogColor = _isDieselPunk ? DieselPunkFogColor : Color.white;

            DOTween.To(() => _ChromaticAberration.intensity.value, x => _ChromaticAberration.intensity.value = x, 1, 1f).OnComplete(() =>
            {
                DOTween.To(() => _ChromaticAberration.intensity.value, x => _ChromaticAberration.intensity.value = x, 0, 4f);
            });
            DOTween.To(() => _LensDistortion.intensity.value, x => _LensDistortion.intensity.value = x, -1, 0.5f).OnComplete(() =>
            {
                DOTween.To(() => _LensDistortion.intensity.value, x => _LensDistortion.intensity.value = x, 0, 2f);
            });
        }
    }
}
