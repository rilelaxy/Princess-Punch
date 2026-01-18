using UnityEngine;

public class Exhaustible : MonoBehaviour
{
    [SerializeField]
    private AudioClip pickUpSoundEffect;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private PlayerInventory playerInventory;

    [Tooltip("Remember to make this value matches other exhaustibles of similar type")]
    [SerializeField]
    private int exhaustibleIndex;

    [Tooltip("Remember to make this value greater than 1")]
    [SerializeField]
    private int amountToAdd = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (audioSource == null)
        {
            Debug.Log("No audio source found!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collect()
    {
        playerInventory.CollectExhaustible(exhaustibleIndex, amountToAdd);
        audioSource.PlayOneShot(pickUpSoundEffect);
    }
}
