using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleDesigner : MonoBehaviourSingleton<HoleDesigner>{

	// This singleton class is responsible for constructing a new hole procedurally. 


	Tile currentTile;		// the current tile where the next piece will be placed
	public Hole hole;				// the hole that is currently being designed
	int numberPieces;		// number of pieces that will comprise this hole
	bool holeComplete = false;	// is the hole design complete?
	int piecesPerFrame = 1;		// how many pieces to draw per frame?
	public int rotation { get; protected set;}	// which way the next tile will be facing	(0, 90, 180, -90);


	// function to call to design a hole

	public void designHole (Hole hole, Tile currentTile, int rotation) {

		//Random.InitState(1);		// can set the seed here for testing


		this.rotation = rotation;
		this.currentTile = currentTile;		// store the start tile
		this.hole = hole;			// store the hole being constructed

		numberPieces = Random.Range (5, 16);		// decide the number of pieces to draw
		numberPieces = 20;			// uncomment to override while testing

		StartCoroutine (PieceLoop ());		// launch coroutine function to loop through the required pieces

	}




	// controls how many pieces to draw in each frame

	IEnumerator PieceLoop () {

		while (numberPieces > 0 && holeComplete == false) {		// while still pieces left to draw

			for (int i = 0; i < Mathf.Min(numberPieces,piecesPerFrame); i++) {	// loop through pieces for this frame
				nextPiece ();		// call function to select the next piece
				numberPieces = numberPieces - 1;		// reduce pieces left to draw
			}

			yield return 0;		// abandon function until next frame

		}

	}


	// returns the next tile in the direction we are heading

	public Tile moveToNextTile (Tile currentTile, int rotation) {	

		Tile nextTile = currentTile;		// set up the next tile

		switch (rotation) {		// return appropriate tile depending on current direction

		case 0:
			nextTile = hole.getTileAt (currentTile.x, currentTile.y + 1, currentTile.z);
			break;

		case 180:
			nextTile = hole.getTileAt (currentTile.x, currentTile.y - 1, currentTile.z);
			break;

		case 90:
			nextTile = hole.getTileAt (currentTile.x + 1, currentTile.y, currentTile.z);
			break;

		case 270:
			nextTile = hole.getTileAt (currentTile.x - 1, currentTile.y, currentTile.z);
			break;

		}

		return nextTile;

	}


	// returns the end tile of the piece we are placing or considering placing

	public Tile getEndTile (Move m) {	

		Vector3 moveBy = m.convertDirection (rotation);	// re-calculate this tile's x,y movement depending on direction

		int newX = currentTile.x + (int)moveBy.x;		
		int newY = currentTile.y + (int)moveBy.y;
		int newZ = currentTile.z + (int)moveBy.z;		// calculate the positions of the final tile covered by this piece

		Tile endTile = hole.getTileAt (newX, newY, newZ);	// get the tile based on these positions

		return endTile;


	}


	// returns a new direction based on a supplied rotation and current direction

	public int nextDirection (int oldRotation, int rotatesBy) {

		int nextRotation = oldRotation + rotatesBy;

		if (nextRotation > 359) {
			nextRotation = nextRotation - 360;		// turn 360 to 0, 450 to 90 etc.
		}

		if (nextRotation < 0) {
			nextRotation = nextRotation + 360;		// turn -90 to 270 etc.
		}

		return nextRotation;

	}



	// get the next piece to place down

	public void nextPiece() {

	//	Debug.Log ("AT " + currentTile.x + " " + currentTile.y + " " + currentTile.z + ", GOING " + rotation);

		List<Piece> validPieces = PieceController.Instance.getValidPieces (currentTile, rotation, hole);
			// ask pieceController for a list of valid pieces we can place here

		int choose = Random.Range (0, validPieces.Count);	// choose one of the pieces

		if (validPieces.Count > 0) {		// if there was at least one valid piece available

			Piece p = validPieces [choose].clone();	// make a copy of the prototype piece
		
			Tile placeTile = moveToNextTile (currentTile, rotation);	// move to the next tile forwards
			p.adjustRotation (rotation);	// set the rotation this piece should abide by

			hole.placePiece (p, placeTile);		// call hole method to place the piece in the grid

			currentTile = getEndTile (p.moves [0]);	// move pointer to the end tile of this piece

			//Debug.Log ("End Tile: " + currentTile.x + " " + currentTile.y + " " + currentTile.z);

			int nextDir = nextDirection ( rotation, p.moves [0].rotatesBy);

			//Debug.Log (rotation + " by " + p.moves [0].rotatesBy + " becomes " + nextDir);

			rotation = nextDir;		// adjust the rotation of the pointer

			Tile nextTile = moveToNextTile (currentTile, rotation);
			//Debug.Log ("Next Tile: " + nextTile.x + " " + nextTile.y + " " + nextTile.z);



		} else {		// a valid piece could not be found - what to do here?

			Debug.LogError ("NO VALID PIECE...");

		}

	}

}
