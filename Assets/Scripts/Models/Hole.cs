using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole{

	public Tile[,,] holeMap;	// a grid of tiles in 3D space that the course pieces can be placed it

	public Piece startPiece;		// a link to the starting piece
	public Piece endPiece;			// a link to the piece containing the hole
	public string skin;				// the prefab 'skin' that will be used for this hole
	public int id;					// the number of the hole
	public GameObject folder;		// the hierarchy folder into which to neatly place its gameObjects

	public int width;			// how many tiles from left to right are available
	public int length;			// how many tiles from back to front are available
	public int depth;			// how many tiles from ground up are available


	// hole constructor

	public Hole (int width, int length, int depth, string skin, int id) {

		this.skin = skin;
		this.id = id;
		this.width = width;
		this.length = length;
		this.depth = depth;		// copy the passed variables

		initialiseHoleMap (width, length, depth);	// initialise the 3D map of tiles

		GameObject folder = new GameObject ();
		folder.name = "Hole " + id;
		folder.transform.SetParent (GameObject.Find ("Holes").transform);
		this.folder = folder;		// create a folder inside the course/holes/ folder for this hole

		int xPos = Random.Range (0, width);
		int zPos = Random.Range (0, length);
		int yPos = Random.Range (0, 0);		// can set a random tile to start from (necessary?)

		Tile startTile = getTileAt (12,12,4);		// get the tile to start from

		placePiece (PieceController.Instance.piecePrototypes ["Start"], startTile);
		startPiece = startTile.installedPiece;		// get the piece installed in the start tile

		int currentRotation = 0;		// start heading north - can adjust this but what's the point - just rotate the hole at the end?

		HoleDesigner.Instance.designHole (this, startTile, currentRotation);
			// ask the holeDesigner class to build a hole from here

	}
		
	public void initialiseHoleMap (int width, int length, int depth) {

		holeMap = new Tile[width, length, depth];	// setup new 3D array of tiles

		for (int x = 0; x < width; x++) {	// loop through each grid position, and create a tile object ther

			for (int y = 0; y < length; y++) {

				for (int z = 0; z < depth; z++) {

					holeMap [x, y, z] = new Tile(x, y, z);
				}
					
			}		// Note: Uses 'Z-Up' notation.

		}

	}


	// returns a tile object held at a given grid position

	public Tile getTileAt (int x, int y, int z) {

		if (x < 0 || x > width - 1 || y < 0 || y > length - 1 || z < 0 || z > depth - 1) {
			return null;
		}		// check the tile asked for is in bounds

		// Note: Grid uses a 'Z-up' system. X = LeftRight, Y = FrontBack, Z = UpDown;
	
		if (holeMap [x, y, z] != null) {

			return holeMap [x, y, z];
		}		// if the tile exists, return it.

		return null;

	}



	// Marks tiles in or around a piece as 'installed', so that another piece cannot be put there.
	// Will block off 'x' tiles above and below in the world to another piece cannot pass under/over with no room to stand. 

	public void blockOffTiles(Piece piece, Tile tile) {

		foreach (Move m in piece.moves) {	// loop through the 'moves' this piece does, i.e. ends 1 tile up and 2 along etc.

			for (int x = (int)m.tilesOccupied[0].x; x <= (int)m.tilesOccupied[1].x; x++) {

				for (int y =  (int)m.tilesOccupied[0].y; y<= (int)m.tilesOccupied[1].y; y++) {

					for (int z = tile.z-1; z < tile.z+2; z++) {

						// loop through all the tiles this piece will claim as its own, denoting distance from home tile

						int blockX = tile.x + m.convertX (x, y, piece.rotation);
						int blockY = tile.y + m.convertY (x, y, piece.rotation);
						// adjust x and y to block depending on the grid position of the 'home' tile.

						Tile t = getTileAt (blockX, blockY, z);	// get the tile to block
						if (t != null) {		// if it exists
							t.installedPiece = piece;		// 'install' the piece in the tile
							if (PieceController.Instance.useDebugCubes) {	// if in debug mode
								PieceController.Instance.placeDebugCube (t);	// draw a debug cube to prove it's blocked
							//Debug.Log ("Block off tile at " + x + "-" + y + "-" + z);
							}
						}
					
					}

				}

			}

		}


	}


	// place a piece object into the 'home' tile, and block off remaining tiles it 'owns'

	public bool placePiece (Piece piece, Tile tile) {
		
		tile.installedPiece = piece;	// piece installed in tile
		piece.tile = tile;			// piece knows which tile it is in
		piece.hole = this;			// piece knows which hole it belongs to

		blockOffTiles (piece, tile);	// block off the other tiles this piece should now own

		if (PieceController.Instance.useDebugCubes) {
			PieceController.Instance.placeDebugCube (tile);	// place debug cube for home tile
		}

		PieceController.Instance.getPiecePrefab (piece);	// create a gameObject to graphically represent piece

		return true;

	}
}
