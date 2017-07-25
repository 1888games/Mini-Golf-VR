using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece {

	public int rotation { get; protected set; }
	public string name;
	public Tile tile;

	public int xSize { get; protected set; }
	public int xOffset {get; protected set; }

	public Hole hole;	
	public int ySize { get; protected set; }

	public List<Move> moves;

	public List<Exit> exits;

	public int difficulty;
	public int frequency;
	public bool splitsPathTwoWays;
	public bool splitsPathThreeWays;



	private Piece (Piece other) {

		rotation = other.rotation;
		name = other.name;
		xSize = other.xSize;
		xOffset = other.xOffset;
		ySize = other.ySize;

		difficulty = other.difficulty;
		frequency = other.frequency;
		splitsPathTwoWays = other.splitsPathTwoWays;
		splitsPathThreeWays = other.splitsPathThreeWays;


		exits = new List<Exit> ();
		moves = new List<Move> ();

		foreach (Exit e in other.exits) {

			exits.Add (e);
		}

		foreach (Move m in other.moves) {

			moves.Add (m);
		}


	}

	public Piece clone() {

		return new Piece (this);

	}

	public void adjustRotation (int rotateTo) {

		rotation = rotateTo;



	}

	public bool canPlaceHere(Tile tile, direction dir, Hole hole) {

		bool okay = true;
		CourseController cc = CourseController.Instance;

		int edge = 3;

	

		foreach (Move m in moves) {

			Vector3 moveBy = m.convertDirection (cc.directionRotationLookup [dir]);

			int newX = tile.x + (int)moveBy.x;
			int newY = tile.y + (int)moveBy.y;
			int newZ = tile.z + (int)moveBy.z;

			if (newX < 0 || (newX < edge && cc.directionRotationLookup [dir] + m.rotatesBy == -90)) {
				okay = false;
			}

			if (newX > hole.width - 1 || (newX > (hole.width - edge - 1) && cc.directionRotationLookup [dir] + m.rotatesBy == 90)) {
				okay = false;
			}

		
			if (newY < 0 || (newY < edge && cc.directionRotationLookup [dir] + m.rotatesBy == 180)) {
				okay = false;
			}

			if (newY > hole.length - 1 || (newY > (hole.length - edge - 1) && cc.directionRotationLookup [dir] + m.rotatesBy == 0)) {
				okay = false;
			}

			if (newZ < 0 || newZ > hole.depth - 1) {
				okay = false;
			}




			//Debug.Log (m.moveString + " would move X " + tile.x + " to " + newX + " OKAY: " + okay);

		}

		if (moves.Count == 0) {

			okay = false;
		}

		return okay;

	}

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

		
		case -90:

			worldPos.x = worldPos.x + 0.5f;
			worldPos.z = worldPos.z + 0.5f;
			break;

		}



		return worldPos;

	}


	public Piece (string name, int xSize, int ySize, int diff, int freq, int xOffset, bool split2 = false, bool split3 = false) {

		exits = new List<Exit> ();
		moves = new List<Move> ();

		this.name = name;
		this.xSize = xSize;
		this.ySize = ySize;
		this.rotation = 0;
		this.difficulty = diff;
		this.frequency = freq;
		this.splitsPathTwoWays = split2;
		this.splitsPathThreeWays = split3;
		this.xOffset = xOffset;


	}



}
