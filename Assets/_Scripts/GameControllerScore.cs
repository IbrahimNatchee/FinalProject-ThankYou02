/* Source File Name: GameController
 * Author's Name: Ibrahim Natchee and Mamunur Rahman
 * Last Modified By: Ibrahim Natchee
 * Date Modified Last: December 17th 2016
 * Program Description: this file is GameController cs file for the game
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




/**  
* <summary>  
* This is the GameController class to control the Game.  
* </summary>  
*   
* @class GameControllerScore  
*/
public class GameControllerScore : MonoBehaviour
{
    // PRIVATE INSTANCE VARIABLES ++++++++++++++++++
    private int _livesValue;
    private int _scoreValue;
	private float timeLeft = 100.0f;
	public int LavelCount;

	// PUBLIC INSTANCE VARIABLES ++++++++++++++++++
    [Header("UI Objects")]
    public Text LivesLabel;
    public Text ScoreLabel;
	public Text TimeCounter;

    // PUBLIC PROPERTIES +++++++++++++++++++++++++++
    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
                this.LivesLabel.text = "Lives: 0";
                SceneManager.LoadScene("GameOver");

            }
            else
            {
                this.LivesLabel.text = "Lives: " + this._livesValue;
            }
        }
    }

    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;
        }
    }



    /**
        * <summary>
        * This is the method for starting the class which initiates value
        * </summary>
        * 
        * @method Start
        * @returns {void} 
        */
    void Start()
    {
        this.LivesValue = 5;
        this.ScoreValue = 0;
		this.LavelCount = 1;
    }

    /**
        * <summary>
        * This method is called once per frame.
        * </summary>
        * 
        * @method Update
        * @returns {void} 
        */
    void Update()
    {
		Scene scene = SceneManager.GetActiveScene();

		if (scene.name=="SecondLevel") {
			timeLeft -= Time.deltaTime;
			TimeCounter.text = "Time Left: " + this.timeLeft;
			if (timeLeft <= 0) {
				//GameOver();
				SceneManager.LoadScene ("GameOver");
			}
		}
    }

	/**
        * <summary>
        * This method is for calling game over scene
        * </summary>
        * 
        * @method GameOver
        * @returns {void} 
        */
	void GameOver(){
		SceneManager.LoadScene("GameOver");

	}

}