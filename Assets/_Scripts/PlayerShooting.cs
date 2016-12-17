﻿/* Source File Name: GameController
 * Author's Name: Ibrahim Natchee and Mamunur Rahman
 * Last Modified By: Ibrahim Natchee
 * Date Modified Last: December 17th 2016
 * Program Description: this file is GameController cs file for the game
 */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerShooting : MonoBehaviour {

	// PUBLIC VARIABLES FOR TESTING
	public Transform FlashPoint;
	public GameObject MuzzleFlash;
	public GameObject Explosion;
	public GameObject BulletImpact;
	public AudioSource RifleShotSound;
	public Transform PlayerCam;

    // PRIVATE VARIABLES
	private int _trollShootCount;

    private GameObject _gameControllerObject;
    private GameControllerScore _gameControllerScore;
	private GameObject _trollControllerObject;
	private TrollController _trollController;
    
	/**
        * <summary>
        * This is the method for starting the class which initiates value
        * </summary>
        * 
        * @method Start
        * @returns {void} 
        */
    void Start () {
		Scene scene = SceneManager.GetActiveScene();
		if (scene.name == "SecondLevel") {
			this._trollControllerObject = GameObject.FindWithTag ("Troll");
			this._trollController = this._trollControllerObject.GetComponent<TrollController> () as TrollController;
			this._trollController.AnimateState = 0;
		}
		this._gameControllerObject = GameObject.Find("GameControllerScore");
        this._gameControllerScore = this._gameControllerObject.GetComponent<GameControllerScore>() as GameControllerScore;

    }
	
	/**
        * <summary>
        * This method is called once per frame.
        * </summary>
        * 
        * @method FixedUpdate
        * @returns {void} 
        */
	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire1")) {
			// show the MuzzleFlash at the FlashPoint without any rotation
			Instantiate (this.MuzzleFlash, this.FlashPoint.position, Quaternion.identity);

			// need a variable to hold the location of our Raycast Hit
			RaycastHit hit;
			//this._trollController.Gothit = false;
			// if raycast hits an object then do something...
			if (Physics.Raycast (this.PlayerCam.position, this.PlayerCam.forward, out hit)) {

				if (hit.transform.gameObject.CompareTag ("Alien")) {
					Instantiate (this.Explosion, hit.point, Quaternion.identity);
                    this._gameControllerScore.ScoreValue = this._gameControllerScore.ScoreValue + 10;
                    Destroy (hit.transform.gameObject);
				}
                 else if (hit.transform.gameObject.CompareTag("Troll"))
                {
					Scene scene = SceneManager.GetActiveScene();
					if (scene.name == "SecondLevel") {
						this._trollController.AnimateState = 1;
					}


					this._gameControllerScore.ScoreValue = this._gameControllerScore.ScoreValue + 30;
					_trollShootCount +=1;
					if (_trollShootCount > 8) {
						Instantiate(this.Explosion, hit.point, Quaternion.identity);
						Destroy (hit.transform.gameObject);
						_trollShootCount = 0;
					}
                }


                else
                {
					Instantiate (this.BulletImpact, hit.point, Quaternion.identity);
				}


			}

			// Play Rifle Sound
			this.RifleShotSound.Play();
		}
	}

	/**
        * <summary>
        * This method is called when 2 objects collides.
        * </summary>
        * 
        * @method OnTriggerEnter
        * @returns {void} 
        */
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Exit")) { 
        SceneManager.LoadScene("SecondLevel");
        }

        //testing
        if (other.gameObject.CompareTag("Exit2"))
        {
            SceneManager.LoadScene("ThirdLevel");
        }

        //

        if (other.gameObject.CompareTag("GoldenCity"))
        {
            SceneManager.LoadScene("GameOver");
        }

		if (other.gameObject.CompareTag("Boss"))
		{
			SceneManager.LoadScene("GameOver");
		}

        if (other.gameObject.CompareTag("Alien")){
			this._gameControllerScore.LivesValue = this._gameControllerScore.LivesValue - 1;
		}
		if (other.gameObject.CompareTag("Troll")){
			this._gameControllerScore.LivesValue = this._gameControllerScore.LivesValue - 1;
		}
        if (other.gameObject.CompareTag("Tikki"))
        {
            this._gameControllerScore.ScoreValue = this._gameControllerScore.ScoreValue + 20;
        }



        }

    
    }
