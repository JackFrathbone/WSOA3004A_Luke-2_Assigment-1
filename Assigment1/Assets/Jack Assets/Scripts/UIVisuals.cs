using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIVisuals : MonoBehaviour
{
    public Image arrowVisual;

    public Color passColor;
    public Color failColor;

    private void Start()
    {
        arrowVisual.gameObject.SetActive(false);
    }

    public void ShowArrow(string direction, bool passed)
    {
        //Just to make sure stuff is reset fully
        StopAllCoroutines();
        arrowVisual.gameObject.transform.rotation = Quaternion.Euler(0f,0f,0f);

        arrowVisual.gameObject.SetActive(true);

        //Rotates the arrow to the correct direction
        switch (direction)
        {
            case "up":
                arrowVisual.gameObject.transform.Rotate(0f, 0f, 0f);
                break;
            case "down":
                arrowVisual.gameObject.transform.Rotate(0f, 0f, 180f);
                break;
            case "left":
                arrowVisual.gameObject.transform.Rotate(0f, 0f, 90f);
                break;
            case "right":
                arrowVisual.gameObject.transform.Rotate(0f, 0f, -90f);
                break;
            default:
                Debug.Log("ShowArrow() direction string not spelt properly");
                break;
        }

        //Sets the color based on if it passes or fails (the right direction)
        if (passed)
        {
            arrowVisual.color = passColor;
        }
        else
        {
            arrowVisual.color = failColor;
        }

        StartCoroutine(WaitAndHideArrow(1f));
    }

    public void HideArrow()
    {
        StopAllCoroutines();
        arrowVisual.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        arrowVisual.gameObject.SetActive(false);
    }

    private IEnumerator WaitAndHideArrow(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        arrowVisual.gameObject.SetActive(false);
    }
}