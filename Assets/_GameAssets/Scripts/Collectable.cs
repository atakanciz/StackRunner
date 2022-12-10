using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Tween rotationTween;
    void Start()
    {
        rotationTween = transform.DORotate(Vector3.up * 180f, Random.Range(.5f, 1.5f))
            .SetLoops(-1, LoopType.Incremental)
            .SetEase(Ease.Linear);
    }

    public void OnCollect()
    {
        DOTween.Kill(rotationTween);
        
        DOTween.Sequence()
            .AppendCallback(() => transform.DOScale(Vector3.zero, .6f).SetEase(Ease.Linear))
            .Append(transform.DOMoveY(transform.position.y + 2f, .65f).SetEase(Ease.Linear))
            .OnComplete(() => Destroy(gameObject));
            
    }
}
