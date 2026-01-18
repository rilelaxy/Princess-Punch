using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Interactable : MonoBehaviour
{

    [SerializeField] private PlayerInventory playerInventory;


    [SerializeField] private TextMeshProUGUI statusText;


    [SerializeField] private AudioSource audioSource;


    [SerializeField] private AudioClip missingSoundEffect;


    [SerializeField] private AudioClip successSoundEffect;


    [SerializeField] private bool giveExhaustibleOnInteract;


    [SerializeField] private int exhaustibleToGiveIndex;


    [SerializeField] private int exhaustibleToGiveAmount;


    [SerializeField] private int exhaustibleRequiredAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerInventory == null) 
        {
            Debug.Log("Player inventory not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseToolInteract(int toolRequiredIndex) 
    {
        //Check if player has tool required to interact, if not, inform them they are missing it.
        if (!playerInventory.tools[toolRequiredIndex])
        {
            audioSource.PlayOneShot(missingSoundEffect);

            statusText.text = "I'm missing something...";

            statusText.gameObject.SetActive(true);
            
            StartCoroutine(DisplayStatusText(5));
            
        }


        else 
        {
            if (giveExhaustibleOnInteract)
            {
                playerInventory.CollectExhaustible(exhaustibleToGiveIndex, exhaustibleToGiveAmount);
                audioSource.PlayOneShot(successSoundEffect);

                Debug.Log("Successfuly interacted and gave " + exhaustibleToGiveAmount + "  of exhaustivle index " + exhaustibleToGiveIndex);
            }
            else 
            {
                audioSource.PlayOneShot(successSoundEffect);
                Debug.Log("Successfuly interacted");
            }
            
        }
    }


    public void UseExhaustibleInteract(int exhaustibleRequiredIndex)
    {
        if (playerInventory.exhaustibles[exhaustibleRequiredIndex] <=0)
        {
            audioSource.PlayOneShot(missingSoundEffect);

            statusText.text = "I'm missing something...";
            
            StartCoroutine(DisplayStatusText(5));
            
        }

        else
        {
            playerInventory.exhaustibles[exhaustibleRequiredIndex] -= 1;
            exhaustibleRequiredAmount -= 1;
            Debug.Log("Used exhaustible");

            if(exhaustibleRequiredAmount == 0) 
            {
                audioSource.PlayOneShot(successSoundEffect);
                Debug.Log("Gave sufficient exhaustibles");
            }
        }
    }

    //Call if delay is needed for any functions
    private IEnumerator DisplayStatusText(float secondsToDelay) 
    {
        statusText.gameObject.SetActive(true);
        yield return new WaitForSeconds(secondsToDelay);
        statusText.gameObject.SetActive(false);
    }

}
