using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButtonAdvance : MonoBehaviour
{
    GameObject mapGenerator;
    ScrollingBackground bg;
    TutorialManager tManage;

    [SerializeField]
    public Button nodeButton;
    [SerializeField]
    public Animator carParent;
    public Animator map;

    float currentRatio = 1;
    float growthSpeed = 0.15f;
    float upperBound = 1.1f;
    float lowerBound = 0.95f;

    // Start is called before the first frame update
    void Start()
    {
        mapGenerator = GameObject.FindWithTag("Map");
        map = mapGenerator.GetComponent<Animator>();
        carParent = GameObject.FindWithTag("car").GetComponent<Animator>();
        bg = GameObject.FindWithTag("Background").GetComponent<ScrollingBackground>();
        tManage = GameObject.FindWithTag("GameManager").GetComponent<TutorialManager>(); ;

    }

    public void Click()
    {
        mapGenerator.GetComponent<MapGenerator>().SelectNode(this.gameObject);
        StartCoroutine(StopCar());

        TutorialManager.tutorialCount++;

    }
    IEnumerator StopCar()
    {
        Debug.Log("StopCar");
        carParent.SetTrigger("stop");
        bg.isScrolling = false;
        map.SetTrigger("fadeout");
        yield return null;
    }
    public void StartPulse()
    {
        StartCoroutine(Pulse());
    }

    IEnumerator Pulse()
    {
        currentRatio = Random.Range(lowerBound, upperBound);

        nodeButton.gameObject.transform.localScale = new Vector3(currentRatio, currentRatio, currentRatio);

        while (nodeButton.enabled && nodeButton.interactable)
        {
            if (!(nodeButton.enabled && nodeButton.interactable))
            {
                break;
            }

            // Get bigger for a few seconds
            while (!(currentRatio >= upperBound))
            {
                if (!(nodeButton.enabled && nodeButton.interactable))
                {
                    break;
                }

                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, upperBound, growthSpeed * Time.deltaTime);

                // Update our text element
                nodeButton.gameObject.transform.localScale = Vector3.one * currentRatio;

                yield return null;
            }

            // Shrink for a few seconds
            while (!(currentRatio <= lowerBound))
            {
                if (!(nodeButton.enabled && nodeButton.interactable))
                {
                    break;
                }

                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, lowerBound, growthSpeed * Time.deltaTime);

                // Update our text element
                nodeButton.gameObject.transform.localScale = Vector3.one * currentRatio;

                yield return null;
            }

            yield return null;
        }

        nodeButton.gameObject.transform.localScale = Vector3.one;
        currentRatio = 1;

        yield return null;
    }
}
