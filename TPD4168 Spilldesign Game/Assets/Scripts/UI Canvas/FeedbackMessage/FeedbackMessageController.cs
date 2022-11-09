using System.Collections;
using TMPro;
using UnityEngine;

public class FeedbackMessageController : MonoBehaviour
{
    [SerializeField] public GameObject feedbackMessage;
    [SerializeField] public GameObject playerStrong;

    // Give Player Feedback Message, e.g "Cannot use this ability, get closer!"
    public IEnumerator AlertFeedbackMessage(string message) {
        Setup(message);
        var newFeedbackMessage = Instantiate(feedbackMessage, playerStrong.transform.position + new Vector3(0, feedbackMessage.GetComponent<FeedbackMessagePosition>().yOffset, 0), Quaternion.identity) ;
        newFeedbackMessage.transform.SetParent(transform, false);
        newFeedbackMessage.GetComponent<Animator>().SetTrigger("popup");

        // the popup animation duration is currently 0.5 seconds
        yield return new WaitForSeconds(0.7f);
        Destroy(newFeedbackMessage);
    }

    public void Setup(string newText) {
        feedbackMessage.GetComponent<TextMeshPro>().text = newText;
    }
}
