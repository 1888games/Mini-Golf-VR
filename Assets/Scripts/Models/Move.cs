using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move {

	// represents how a piece would move us in the hole grid. i.e. move forward 1, right 2, rotate by 90 degs.

	public int rotatesBy { get; protected set; }	// how much this move would change direction
	public string moveString {get; protected set;}	// a string to enable a piece to add a move by its name

	public Vector2 [] tilesOccupied = {Vector2.zero, Vector2.zero};	// tiles that this 'move' would also mark as occupied to prevent intersects

	public Vector3 direction;	// the direction this move would take us in (i.e. 1 left, 2 forward, -1 up);
	
	public Move (int LR, int FB, int UD, int rot, Vector2[] tiles) {

		this.rotatesBy = rot;		// store the rotation that this move would rotate pointer by

		this.moveString = "LR " + LR + " FB " + FB + " UD " + UD + " RO " + rot;	// calculate the easy lookup string

		this.direction = new Vector3((float)LR,(float)FB,(float)UD);	// calculate the direction vector

		tilesOccupied [0] = new Vector2 (tiles [0].x, tiles [0].y);		// create an address for the bottom left tile to occupy
		tilesOccupied [1] = new Vector2 (tiles [1].x, tiles [1].y);		// create an address for the top left tile to occupy

	}

	// calculate how moving 'forward' etc at 0 degrees is represented in X-axis of world space at given rotation.

	public int convertX (int x, int y, int rotate) {
		
		switch (rotate) {

		case 90:

			x = y;
			break;

		case 180:

			x = -x;
			break;

		case 270:

			x = -y;
			break;

		}

		return x;

	}

	// calculate how moving 'forward' etc at 0 degrees is represented in Y-axis of world space at given rotation.

	public int convertY (int x, int y, int rotate) {

		switch (rotate) {

		case 90:

			y = -x;
			break;

		case 180:

			y = -y;
			break;

		case 270:
			
			y = x;
			break;

		}

		return y;

	}


	// calculate how the direction of a given move changes in world space based on current rotation

	public Vector3 convertDirection (int rotate) {

		Vector3 rotated = direction;
		switch (rotate) {

		case 90:

			float origX = rotated.x;
			rotated.x = rotated.y;
			rotated.y = -origX;
			break;

		case 180:

			rotated.y = -rotated.y;
			rotated.x = -rotated.x;
		
			break;
	
		case 270:

			float origX2 = rotated.x;
			rotated.x = -rotated.y;
			rotated.y = origX2;
			break;

		}

		//Debug.Log (moveString + " - " + direction + " - " + rotated);

		return rotated;

	}


}
