using System.Collections;
using UnityEngine;

public class CatUse : MonoBehaviour
{
    public bool isHolding = false;
    private GameObject useObject;
    private GameObject holdingObject;
    private GameObject dum;
    [SerializeField] private GameObject sign;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("UseItem") || collision.CompareTag("Item"))
        {
            dum = collision.gameObject;
            
            if (dum.GetComponent<UseItem>() && dum.GetComponent<UseItem>().enabled == false || dum.GetComponent<DanceMan>())
            {              
                sign.SetActive(true);
                sign.transform.position = dum.transform.position;
            }
            else if (dum.GetComponent<HoldItem>() && dum.GetComponent<HoldItem>().enabled == false)
            {
                sign.SetActive(true);
                sign.transform.position = dum.transform.position;
            }
            else if (isHolding)
            {
                sign.SetActive(false);
            }
        }
        else if (dum == null)
        {
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (sign != null && (collision.CompareTag("UseItem") || collision.CompareTag("Item")))
        {
            sign.SetActive(false);
        }
    }


    public void Use()
    {
        if (!isHolding && dum != null)
        {
            if (dum.CompareTag("Item"))
            {
                sign.SetActive(false);
                holdingObject = dum;
                holdingObject.GetComponent<HoldItem>().enabled = true;
                isHolding = true;
            }
            else if (dum.CompareTag("UseItem") && !dum.GetComponent<UseItem>().enabled)
            {
                useObject = dum;
                useObject.GetComponent<UseItem>().enabled = true;
                dum = null;
                sign.SetActive(false);
            }
            else if (dum.GetComponent<DanceMan>())
            {
                useObject = dum;
                useObject.GetComponent<UseItem>().enabled = true;
                dum = null;
            }
        }
    }
    public void Drop()
    {
        if (isHolding)
        {
            StartCoroutine(wait());
            holdingObject.GetComponent<HoldItem>().enabled = false;
            dum = null;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        isHolding = false;
    }
 }
