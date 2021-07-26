using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashController : MonoBehaviour
{
    Collider objectCol;
    private GameController gameController;
    private bool haveCut = false;
    public bool destroyTimerStart = false;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        objectCol = gameObject.GetComponent<Collider>();
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyTimerStart)
        {
            destroyAfterAWhile();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !haveCut)
        {
            objectCol.isTrigger = false;
            haveCut = true;
            Transform originalTransform = gameObject.transform;
            Vector3 orginalPosition = originalTransform.position;
            Vector3 cloneScale = new Vector3(originalTransform.localScale.x, originalTransform.localScale.y, originalTransform.localScale.z/2);
            Vector3 clonePositionRight = new Vector3(orginalPosition.x, orginalPosition.y, orginalPosition.z + originalTransform.localScale.z/3);
            Vector3 clonePositionLeft = new Vector3(orginalPosition.x, orginalPosition.y, orginalPosition.z - originalTransform.localScale.z/3);

            GameObject leftClone = Instantiate(gameObject, clonePositionLeft, Quaternion.identity);
            leftClone.transform.localScale = cloneScale;
            Rigidbody leftCloneRb = leftClone.GetComponent<Rigidbody>();
            SlashController leftCloneSC = leftClone.GetComponent<SlashController>();
            leftCloneSC.destroyTimerStart = true;
            leftCloneRb.useGravity = true;
            leftCloneRb.AddForce(0, 200, -20);

            GameObject rightClone = Instantiate(gameObject, clonePositionRight, Quaternion.identity);
            rightClone.transform.localScale = cloneScale;
            Rigidbody rightCloneRb = rightClone.GetComponent<Rigidbody>();
            SlashController rightCloneSC = rightClone.GetComponent<SlashController>();
            rightCloneSC.destroyTimerStart = true;
            rightCloneRb.useGravity = true;
            rightCloneRb.AddForce(0, 200, 20);
            Destroy(gameObject);

            gameController.increasePoint();

        }
    }

    private void destroyAfterAWhile()
    {
        time += Time.deltaTime;
        if(time > 3f)
        {
            Destroy(gameObject);
        }
    }

}
