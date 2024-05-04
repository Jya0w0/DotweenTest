using UnityEngine;
using DG.Tweening;

public class DotweenExampleTo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 큐브의 Transform을 가져옵니다.
        Transform cubeTransform = this.transform;

        // 시퀀스를 생성합니다.
        Sequence mySequence = DOTween.Sequence();

        // 크기를 2배로 증가시키는 애니메이션을 추가합니다.
        mySequence.Append(cubeTransform.DOScale(new Vector3(2, 2, 2), 2));

        // 2초간 대기합니다.
        mySequence.AppendInterval(2);

        // 오른쪽으로 이동시킵니다 (여기서는 x축으로 +2만큼).
        mySequence.Append(cubeTransform.DOMoveX(cubeTransform.position.x + 2, 2));

        // Y축을 중심으로 90도 회전합니다.
        mySequence.Join(cubeTransform.DORotate(new Vector3(0, 90, 0), 2, RotateMode.LocalAxisAdd));
        
        // 크기를 0으로 만들어 없앱니다.
        mySequence.Append(cubeTransform.DOScale(Vector3.zero, 2).SetEase(Ease.OutBounce));

        // 시퀀스를 무한 반복하도록 설정합니다.
        mySequence.SetLoops(-1);

        // 시퀀스를 재생합니다.
        mySequence.Play();
    }
}
