using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseController : MonoBehaviourSingleton<CourseController> {

	public Course currentCourse;
	public Dictionary<direction, int> directionRotationLookup;
	public Dictionary<direction, int> rotationDirectionLookup;

	public string[] skins = { "Beach", "Road", "Grass" };

	// Use this for initialization
	void Start () {

		directionRotationLookup = new  Dictionary<direction, int> ();


		directionRotationLookup.Add (direction.North, 0);
		directionRotationLookup.Add (direction.South, 180);
		directionRotationLookup.Add (direction.East, 90);
		directionRotationLookup.Add (direction.West, -90);


		newCourse (1);



	}


	void newCourse(int holes) {

		currentCourse = new Course ();

		for (int i = 0; i < holes; i++) {

			newHole (i+1);

		}





	}

	void newHole (int id) {


		Hole newHole = new Hole (25, 25, 25, skins[Random.Range(0,3)], id);
	
		currentCourse.holes.Add (newHole);




	}


	// Update is called once per frame
	void Update () {
		
	}
}
