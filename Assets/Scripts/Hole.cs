using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole{

	public HoleDesigner holeDesigner;
	public Tile[,,] holeMap;

	public Piece startPiece;
	public Piece endPiece;
	public string skin;
	public int id;
	public GameObject folder;

	public int width;
	public int length;
	public int depth;

	public Hole (int width, int length, int depth, string skin, int id) {

		this.holeDesigner = new HoleDesigner ();
		this.skin = skin;
		this.id = id;
		this.width = width;
		this.length = length;
		this.depth = depth;

		initialiseHoleMap (width, length, depth);

		GameObject folder = new GameObject ();
		folder.name = "Hole " + id;
		folder.transform.SetParent (GameObject.Find ("Holes").transform);
		this.folder = folder;

		int xPos = Random.Range (0, width);
		int zPos = Random.Range (0, length);
		int yPos = Random.Range (0, 0);

		//Debug.Log (xPos + " " + zPos + " " + yPos);
	
	//	Tile startTile = getTileAt (xPos, zPos, yPos);
		Tile startTile = getTileAt (12,12,12);

		//Debug.Log (startTile);
		placePiece (PieceController.Instance.piecePrototypes ["Start"], startTile);

		direction currentDir = direction.North;

		holeDesigner.designHole (this, startTile, currentDir);





	}


	void designHole() {






	}


	public Tile getTileAt (int x, int z, int y) {

	
		if (holeMap [x, z, y] != null) {

			return holeMap [x, z, y];
		}

		return null;

	}

	public void initialiseHoleMap (int width, int length, int depth) {

		holeMap = new Tile[width, length, depth];

		for (int x = 0; x < width; x++) {

			for (int z = 0; z < length; z++) {

				for (int y = 0; y < depth; y++) {

					holeMap [x, z, y] = new Tile(x, z, y);
				}


			}

		}

	}


	public bool placePiece (Piece piece, Tile tile) {

		bool success = false;

		tile.installedPiece = piece;
		piece.tile = tile;
		piece.hole = this;



		//Debug.Log (tile.installedPiece);
		//Debug.Log (piece.tile.x + " + " + piece.tile.y + " + " + piece.tile.z);

		PieceController.Instance.getPiecePrefab (piece);



		return success;

	}
}
