using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public enum ActionType
{
    Move,
    MoveX,
    MoveY,
    MoveXAnchored,
    Scale,
    Rotate,
    Color,
    Fade,
    Shake
}

public class DotweenExample : MonoBehaviour
{
    private Button btn;
    private Image img;
    private RectTransform rect;

    [SerializeField] private ActionType actionType;

    [SerializeField] private Ease easeType;

    [SerializeField] private float duration;

    [SerializeField] private Vector3 paramVector;
    
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(DoMove);

        rect = GetComponent<RectTransform>();
        img = GetComponent<Image>();
    }

    private void DoMove()
    {
        switch (actionType)
        {
            case ActionType.Move:
                rect.DOMove(transform.position + paramVector * 20f, duration)
                    .SetEase(easeType);
                break;
            case ActionType.MoveX:
                rect.DOMoveX(paramVector.x, duration)
                    .SetEase(easeType);
                break;
            case ActionType.MoveY:
                rect.DOMoveY(paramVector.y, duration)
                    .SetEase(easeType);
                break;
            case ActionType.MoveXAnchored:
                rect.DOAnchorPosX(paramVector.x, duration)
                    .SetEase(easeType);
                break;
            case ActionType.Scale:
                rect.DOScale(paramVector, duration)
                    .SetEase(easeType);
                break;
            case ActionType.Rotate:
                rect.DORotate(paramVector, duration);
                break;
            case ActionType.Color:
                img.DOColor(Color.red, duration)
                    .SetEase(easeType);
                break;
            case ActionType.Fade:
                img.DOFade(0f, duration)
                    .SetEase(easeType);
                break;
            case ActionType.Shake:
                rect.DOShakePosition(duration, 20f);
                break;
            default:
                break;
        }
    }
}
