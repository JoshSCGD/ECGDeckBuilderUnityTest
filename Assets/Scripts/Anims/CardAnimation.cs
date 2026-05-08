using UnityEngine;
using DG.Tweening;

public class CardAnimation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _duration = 0.35f;
    [SerializeField] private float _popScale = 1.15f;
    [SerializeField] private float _spinIntensity = 8f;

    private Vector3 _startScale;

    private void Awake()
    {
        _startScale = transform.localScale; //cache scale on runtime
    }

    private void Start()
    {
        PlayAnimation(); //I resorted to playing the anim instantly as suppose to lerping from the deck to a new pos in world space
    }

    public void PlayAnimation() //most things regarding this func I had to look up. this was my first time using this plugin :)
    {
        transform.localScale = Vector3.zero;
        transform.rotation = Quaternion.identity;

        Sequence sequence = DOTween.Sequence(); //define sequence 

        
        sequence.Append(transform.DOScale(_popScale, _duration)
            .SetEase(Ease.OutBack));

        sequence.Join(transform.DORotate(new Vector3(0, 0, _spinIntensity), _duration)
            .SetEase(Ease.OutSine));

        sequence.Append(transform.DOScale(_startScale, _duration * 0.5f)
            .SetEase(Ease.InOutSine));

        sequence.Join(transform.DORotate(Vector3.zero, _duration * 0.5f)
            .SetEase(Ease.InOutSine));
    }
}