using UnityEngine;

public class Tool : MonoBehaviour
{
    [SerializeField]
    private AudioClip pickUpSoundEffect;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private PlayerInventory playerInventory;

    [Tooltip("Remember to make this value unique from all other tools")]
    [SerializeField]
    private int toolIndex;

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
        playerInventory.CollectTool(toolIndex);
        audioSource.PlayOneShot(pickUpSoundEffect);
    }
}
