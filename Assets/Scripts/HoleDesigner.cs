using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleDesigner {



	Tile currentTile;
	direction currentDirection;
	Hole hole;

	public void designHole (Hole hole, Tile currentTile, direction currentDirection) {


		this.currentTile = currentTile;
		this.currentDirection = currentDirection;
		this.hole = hole;

		int numberPieces = 16;
		bool holeComplete = false;


		while (numberPieces > 0 && holeComplete == false) {

			nextPiece ();

			numberPieces = numberPieces - 1;


		}


	}


	public void moveToNextTile () {

		switch (currentDirection) {

		case direction.North:
			currentTile = hole.getTileAt (currentTile.x, currentTile.y + 1, currentTile.z);
			break;

		case direction.South:
			currentTile = hole.getTileAt (currentTile.x, currentTile.y - 1, currentTile.z);
			break;

		case direction.East:
			currentTile = hole.getTileAt (currentTile.x + 1, currentTile.y, currentTile.z);
			break;

		case direction.West:
			currentTile = hole.getTileAt (currentTile.x - 1, currentTile.y, currentTile.z);
			break;

		}


	}


	public Tile getEndTile (Move m) {

		Vector3 moveBy = m.convertDirection (CourseController.Instance.directionRotationLookup [currentDirection]);

		int newX = currentTile.x + (int)moveBy.x;
		int newY = currentTile.y + (int)moveBy.y;
		int newZ = currentTile.z + (int)moveBy.z;

		Tile endTile = hole.getTileAt (newX, newY, newZ);

		return endTile;


	}

	void changeDirection (int rotatesBy) {

		switch (rotatesBy) {

		case 90:
			
			switch (currentDirection) {

			case direction.North:
				currentDirection = direction.East;
				break;

			case direction.East:
				currentDirection = direction.South;
				break;

			case direction.South:
				currentDirection = direction.West;
				break;

			case direction.West:
				currentDirection = direction.North;
				break;
		
			}

			break;

		case -90:

			switch (currentDirection) {

			case direction.North:
				currentDirection = direction.West;
				break;

			case direction.East:
				currentDirection = direction.North;
				break;

			case direction.South:
				currentDirection = direction.East;
				break;

			case direction.West:
				currentDirection = direction.South;
				break;

			}

			break;
		

		case 180:

			switch (currentDirection) {

			case direction.North:
				currentDirection = direction.South;
				break;

			case direction.East:
				currentDirection = direction.West;
				break;

			case direction.South:
				currentDirection = direction.North;
				break;

			case direction.West:
				currentDirection = direction.East;
				break;

			}

			break;

		}

	}





	public void nextPiece() {

		//	Debug.Log ("AT " + currentTile.x + " " + currentTile.y + " " + currentTile.z + ", GOING " + currentDirection);

		List<Piece> validPieces = PieceController.Instance.getValidPieces (currentTile, currentDirection, hole);

		int choose = Random.Range (0, validPieces.Count);

		if (validPieces.Count > 0) {

			Debug.Log ("CURRENT: " + currentTile.x + " " + currentTile.y + " " + currentTile.z);

			Piece proto = validPieces [choose];

			Piece p = proto.clone ();

			Debug.Log ("CHOSEN PIECE: " + p.name + " BY " + p.moves[0].convertDirection(CourseController.Instance.directionRotationLookup [currentDirection]));

			Tile endTile = getEndTile (p.moves [0]);

			Debug.Log ("END: " + endTile.x + " " + endTile.y + " " + endTile.z);

			moveToNextTile ();

		

			p.adjustRotation (CourseController.Instance.directionRotationLookup [currentDirection]);

			hole.placePiece (p, currentTile);

			Debug.Log ("PLACE AT: " + currentTile.x + " " + currentTile.y + " " + currentTile.z + " GOING " + currentDirection);


			currentTile = endTile;



			changeDirection (p.moves [0].rotatesBy);


		} else {

			Debug.Log ("NO VALID PIECE...");

		}

	}

}
