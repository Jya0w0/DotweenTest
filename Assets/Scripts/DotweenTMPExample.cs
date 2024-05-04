using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class DotweenTMPExample : MonoBehaviour
{
    private Button btn;
    private Text text;
    private Sequence sequence;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        text = GetComponent<Text>();

        btn.onClick.AddListener(OnPlay);
        sequence = DOTween.Sequence().SetAutoKill(false).Pause();
        sequence.Append(text.DOText("Hello, Thank you, See you, Later", 2f).From(""));
        sequence.Append(text.DOColor(Color.red, 1f).SetDelay(2f));
        sequence.AppendCallback(() => Debug.Log("Happy!"));
        sequence.SetLoops(-1, LoopType.Yoyo); // -1은 무제한 , 루프는 한번 가는게 1번 왕복 2번
    }

    void OnPlay()
    {
        sequence.Play();
    }
}
