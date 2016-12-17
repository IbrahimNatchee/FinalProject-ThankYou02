/* Source File Name: GameController
 * Author's Name: Ibrahim Natchee and Mamun Rahman
 * Last Modified By: Ibrahim Natchee
 * Date Modified Last: December 5th 2016
 * Program Description: To create and control UI
 * Revision History: December 5th 2016
 
 */

using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public UnityEngine.AI.NavMeshAgent Agent;
	public bool Gothit;
    //
    public Transform target;
    //

    // PRIVATE INSTANCE VARIABLES

    private Transform Player;

	/**
        * <summary>
        * This is the method for starting the class which initiates value
        * </summary>
        * 
        * @method Start
        * @returns {void} 
        */
	void Start () {
		this.Player = GameObject.FindWithTag ("Player").transform;


	}
	
	/**
        * <summary>
        * This method is called once per frame.
        * </summary>
        * 
        * @method FixedUpdate
        * @returns {void} 
        */
	void Update () {
		this.Agent.SetDestination (this.Player.position);
        //
        if (target != null)
        {
            transform.LookAt(target);
        }
        //


    }



}
