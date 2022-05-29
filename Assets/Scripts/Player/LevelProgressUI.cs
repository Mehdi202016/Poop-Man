using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
    //UI References
    [SerializeField] private Image UiFillImage;
    [SerializeField] private Text  UiStartText;
    [SerializeField] private Text  UiEndText;

    //Object Refenrences
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private Transform endLineTransform;

    private Vector3 EndLinePosition;
    private float fullDistance;
    private void Start()
    {
        EndLinePosition = endLineTransform.position;
        fullDistance = GetDistance();
    }
    public void SetLevelsText(int level)
    {
        UiStartText.text = level.ToString();
        UiEndText.text = (level + 1).ToString();
    }

    private float GetDistance()
    {
        //return Vector3.Distance(PlayerTransform.position, endLineTransform.position);
        return (EndLinePosition-PlayerTransform.position).sqrMagnitude;
    }

    void UpdateProgress(float value) 
    {
        UiFillImage.fillAmount = value;
    }
    private void Update()
    {
        if (PlayerTransform.position.z <= EndLinePosition.z)
        {
            //UpdateProgress(fullDistance);
            float newDistance = GetDistance();
            float ProgressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);
            UpdateProgress(ProgressValue);
        }

    }

}
