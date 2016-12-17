/* Source File Name: GameController
 * Author's Name: Ibrahim Natchee and Mamunur Rahman
 * Last Modified By: Ibrahim Natchee
 * Date Modified Last: December 17th 2016
 * Program Description: this file is GameController cs file for the game
 */
using UnityEngine;
using System.Collections;

// reference to the UI namespace
using UnityEngine.UI;

// reference to manage my scenes
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour {




	/**
        * <summary>
        * This is the method for starting the class which initiates value
        * </summary>
        * 
        * @method Start
        * @returns {void} 
        */
	void Start () {

	}
	
	/**
        * <summary>
        * This method is called once per frame.
        * </summary>
        * 
        * @method Update
        * @returns {void} 
        */
	void Update () {
		
	}

	/**
        * <summary>
        * This method is to restart the game.
        * </summary>
        * 
        * @method ReStartButtonClick
        * @returns {void} 
        */
	public void ReStartButtonClick()
	{
		SceneManager.LoadScene("InDoors");

	}
}
