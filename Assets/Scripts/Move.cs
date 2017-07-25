using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move {

	public int leftRight {get; protected set;}
	public int forwardBack {get; protected set;}
	public int upDown {get; protected set;}
	public int rotatesBy { get; protected set; }

	public string moveString {get; protected set;}

	public List<Vector2> tilesOccupied;

	public Vector3 direction;
	
	public Move (int LR, int FB, int UD, int rot, List<Vector2> tiles) {

		this.leftRight = LR;
		this.forwardBack = FB;
		this.upDown = UD;
		this.rotatesBy = rot;
		this.moveString = "LR " + LR + " FB " + FB + " UD " + UD + " RO " + rot;

		this.direction = new Vector3((float)LR,(float)FB,(float)UD);

		tilesOccupied = tiles;

		convertDirection (90);

		//Debug.Log (moveString);

	}



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
	
		case -90:

			float origX2 = rotated.x;
			rotated.x = -rotated.y;
			rotated.y = origX2;
			break;

		}

		//Debug.Log (moveString + " - " + direction + " - " + rotated);

		return rotated;

	}


}
