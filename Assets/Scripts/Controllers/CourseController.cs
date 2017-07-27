using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseController : MonoBehaviourSingleton<CourseController> {

	// reponsible for managing the course, including its initial creation.

	public Course currentCourse;			// keep reference to the current course being played
	public string[] skins = { "Beach", "Road", "Grass" };	// the available skins for course pieces

	// Use this for initialization
	void Start () {
			
		newCourse (1);		// call function to create a new course

	}


	// loop through the holes required and create them

	void newCourse(int holes) {		

		currentCourse = new Course ();

		for (int i = 0; i < holes; i++) {

			newHole (i+1);

		}

	}

	// sets up a new hole object, with given boundaries and skin.

	void newHole (int id) {

		Hole newHole = new Hole (25, 25, 7, skins[Random.Range(0,3)], id);
	
		currentCourse.holes.Add (newHole);		// add the hole to the course

	}


	// Update is called once per frame
	void Update () {
		
	}
}
