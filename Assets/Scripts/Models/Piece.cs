using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece {

	public int rotation { get; protected set; }		// the rotation of this piece in world space
	public string name;		// the name of the piece for easy lookup (i.e. Curve01);
	public Tile tile;		// the 'home' tile that this piece is installed in
	public Hole hole;		// the hole this piece belongs to
	public List<Move> moves;	// the 'moves' this piece makes. Generally only 1 expect t-junctions and crossroads.

	public int difficulty;		// the difficulty this piece represents (1-5)
	public int frequency;		// how frequently the piece should be chosen (1-5)
	public int edge = 2;	// how many tiles from the edge to avoid placing pieces
	public int lookAhead = 5;	// how many tiles to look ahead from end to make sure there's space
	public int lookUnderOver = 1;	// how many tiles below/above to check there's space
	public int lookLeftRight = 1;	// how many tiles below/above to check there's space

	// this constructor only creates prototypes based on data passed by PieceData

	public Piece (string name, int diff, int freq) {

		moves = new List<Move> ();	// instantiate a list in which to place move objects
	
		this.name = name;
		this.rotation = 0;
		this.difficulty = diff;
		this.frequency = freq;	// copy stuff passed from PieceData
	
	}


	// called by the 'clone' function to give a copy of the prototype

	private Piece (Piece other) {

		rotation = other.rotation;
		name = other.name;
		difficulty = other.difficulty;
		frequency = other.frequency;	// copy the values from the prototype
	
		moves = new List<Move> ();

		foreach (Move m in other.moves) {
			moves.Add (m);
		}


	}

	// create a new instance from the prototype

	public Piece clone() {

		return new Piece (this);

	}



	public void adjustRotation (int rotateTo) {

		rotation = rotateTo;	// setter to adjust rotation of piece

	}


	// check whether the end tile of the move would take us out of bounds (or too close)

	public bool checkBoundary(Move m, int newX, int newY, int newZ, int dir, Hole hole) {


		if (newX < 0 || (newX < edge && dir + m.rotatesBy == -90)) {
			return false;		// left boundary
		}

		if (newX > hole.width - 1 || (newX > (hole.width - edge - 1) && dir + m.rotatesBy == 90)) {
			return false;		// right boundary
		}


		if (newY < 0 || (newY < edge && dir + m.rotatesBy == 180)) {
			return false;		// far boundary
		}

		if (newY > hole.length - 1 || (newY > (hole.length - edge - 1) && dir + m.rotatesBy == 0)){
			return false;		// near boundary
		}

		if (newZ < 0 || newZ > hole.depth - 1) {
			return false;		// up/down boundary
		}



		return true;
	}

	// decide whether this piece can be placed in the passed tile and given rotation

	public bool checkAhead(Move m, Tile endTile, int rotation, Hole hole) {

		if (endTile == null) {		// end tile would be out of bounds..
			return false;
		}

		for (int i = 0; i < lookAhead; i++) {	// loop through the number of steps forward to check

			if (i > 0) {		// if not looking at the initial end tile, get the next one along
				endTile = HoleDesigner.Instance.moveToNextTile (endTile, rotation );	// get the tile where the piece would be placed
				//Debug.Log("LOOK AHEAD: " + endTile.x + " " + endTile.y + " " + endTile.z);
			}

			if (endTile == null) {
				return false;
			}

			for (int k = -lookLeftRight; k <= lookLeftRight; k++) {		// look at tiles below, at and obove

				for (int j = -lookUnderOver; j <= lookUnderOver; j++) {		// look at tiles below, at and obove

					Tile t = hole.getTileAt (endTile.x + m.convertX (k, 0, rotation), endTile.y + m.convertY (k, 0, rotation), endTile.z + j);	// get the tile at this address
					//Debug.Log ("LOOK LEFTRIGHTUPDOWN: " + t.x + " " + t.y + " " + t.z);

					if (t != null && t.installedPiece != null) {	// if the tile has been blocked off, return false
						//Debug.Log ("Occupied tile to the left or right");
						return false;
					}

				}

			}

	
			
		}

		return true;
	}

	public bool checkWithin (Move m, Tile tile, Tile nextTile, Hole hole) {
		
		for (int x = (int)m.tilesOccupied[0].x; x <= (int)m.tilesOccupied[1].x; x++) {

			for (int y =  (int)m.tilesOccupied[0].y; y<= (int)m.tilesOccupied[1].y; y++) {

				for (int z = nextTile.z - 2; z < nextTile.z + 3; z++) {

					// loop through all the grid positions (from piece origin of (0,0) this piece will own;
					
					Tile t = hole.getTileAt (nextTile.x + m.convertX(x,y,rotation), 
						nextTile.y + m.convertY(x,y,rotation), z);	
					// get the tile this represents from home tile given rotation

					if (t != null && tile != null && (t.x != tile.x || t.y != tile.y) && t.installedPiece != null) {	// if the tile exists and already occupied
						//Debug.Log (name + "  Can't build here...");

						return false;
					}

				}

			}


		}


		return true;
	}

	public bool canPlaceHere(Tile tile, int rotation, Hole hole) {

		if (moves.Count == 0) {
			Debug.Log ("No moves found for piece " + name);
			return false;		// probably initial start tile...
		}

		foreach (Move m in moves) {		// loop through the moves that might take us into illegal territory

			Vector3 moveBy = m.convertDirection (rotation);		// get where the piece would move us to, based on heading

			int afterMoveRotation = HoleDesigner.Instance.nextDirection (rotation, m.rotatesBy);
			int newX = tile.x + (int)moveBy.x;
			int newY = tile.y + (int)moveBy.y;
			int newZ = tile.z + (int)moveBy.z;	// calculate the new grid positions we'd arrive at 

			if (checkBoundary (m, newX, newY, newZ, rotation, hole) == false) {
				return false;		// check whether the end tile would be out of bounds (or near)
			}

			//
			Tile endTile = hole.getTileAt (newX, newY, newZ);	// go to end tile of piece

			//Debug.Log (name + " Last tile of this move is " + newX + " " + newY + " " + newZ);


			if (checkAhead (m, endTile, afterMoveRotation, hole) == false) {
				return false;	// check ahead, below and above of end tile for potential blockages

			}

			Tile nextTile = HoleDesigner.Instance.moveToNextTile (tile, rotation);	// get the tile where the piece would be placed

			if (checkWithin (m, tile, nextTile, hole) == false) {
				return false;

			}
	

		}
			
		return true;	// all checks passed

	}

	// returns the world position that a piece gameObject should be placed at to line up with its grid position.

	public Vector3 getWorldPosition() {

		Vector3 worldPos = new Vector3 (tile.x + 0.5f, tile.z + 0.2f, tile.y);

		switch (rotation) {

		case 90:

			worldPos.x = worldPos.x - 0.5f;
			worldPos.z = worldPos.z + 0.5f;
			break;

		case 180:

			worldPos.x = worldPos.x - 0f;
			worldPos.z = worldPos.z + 1f;
			break;

		
		case 270:

			worldPos.x = worldPos.x + 0.5f;
			worldPos.z = worldPos.z + 0.5f;
			break;

		}

		return worldPos;

	}




}
