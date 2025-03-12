using TMPro;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private float duration;
    [SerializeField] private Ease animationCurve;

    private float containerInitPos;
    private float moveAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPos = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }

    public void UpdateScore(int score)
    {
        toUpdate.SetText($"{score}");
        coinTextContainer.DOLocalMoveY(containerInitPos + moveAmount, duration).SetEase(animationCurve);

        StartCoroutine(ResetCoinCounter(score));
    }

    private IEnumerator ResetCoinCounter(int score)
    {
        yield return new WaitForSeconds(duration);

        current.SetText($"{score}");
        Vector3 localPos = coinTextContainer.localPosition;
        coinTextContainer.localPosition = new Vector3(localPos.x, containerInitPos, localPos.z);
    }
}
