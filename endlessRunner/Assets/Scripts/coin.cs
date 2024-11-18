using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COIN : MonoBehaviour
{

    public AudioSource CoinFX;
    // Start is called before the first frame update


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,50 * Time.deltaTime, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {

            if (playerControl.checker == 1)
            {
                playerControl.numberOfCoins += 2;

                Debug.Log("Coins:" + playerControl.numberOfCoins);
                CoinFX.Play();
                Destroy(gameObject);
            }
            else
            {
                playerControl.numberOfCoins += 1;

                Debug.Log("Coins:" + playerControl.numberOfCoins);
                CoinFX.Play();
                Destroy(gameObject);
            }
        }

    }

}
