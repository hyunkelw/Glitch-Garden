using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{

    // Cached references
    Text tooltipText;
    RectTransform backgroundRectTransform;

    private void Awake()
    {
        backgroundRectTransform = GetComponent<RectTransform>();
        tooltipText = backgroundRectTransform.GetComponentInChildren<Text>();
    }

    private void Start()
    {
        HideTooltip();
    }

    private void Update()
    {
        Vector2 localPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(localPoint);
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out localPoint);
        transform.localPosition = localPoint;
    }

    public void ShowTooltip(string tooltipString)
    {
        gameObject.SetActive(true);
        tooltipText.text = tooltipString;
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(tooltipText.preferredWidth + textPaddingSize * 2, tooltipText.preferredHeight + textPaddingSize * 2);
        backgroundRectTransform.sizeDelta = backgroundSize;
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

}
