using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PieceController : MonoBehaviourSingleton<PieceController> { 

	// This singleton class is responsible for checking pieces are valid to place down, and
	// creating and placing the actual game objects in the world.

	public Dictionary<string, Piece> piecePrototypes;	// holds piece data prototypes
	public Dictionary<Piece, GameObject> pieceToGameObjectMap;	// links piece data to its gameObject
	public Dictionary<string, GameObject> piecePrefabs;		// links to the piece prefab objects
	public List <Move> moves;		// a list of moves that this piece can do (t-juncs and cross-roads take a path off in multiple directions)
	public Dictionary <string, Move> moveNameMap;		// links move objects with a name so it can be easily added to a piece
	public GameObject debugCube;		// cube displayed when a grid square has been made unavailable for new pieces
	public bool useDebugCubes = false;

	// Use this for initialization
	void Start () {

		moveNameMap = new Dictionary<string, Move> ();	
		moves = new List<Move> ();
		piecePrefabs = new Dictionary<string, GameObject> ();
		piecePrototypes = new Dictionary<string, Piece> ();	// instantiate the various lists/dictionaries
		pieceToGameObjectMap = new Dictionary<Piece, GameObject> ();	// instantiate the various lists/dictionaries

		createPiecePrototypes ();	// will use data from MoveData and PieceData to create move and piece objects
		loadPiecePrefabs ();		// grabs the prefabs from the prefabs gameObject hierarchy into a dictionary

	}

	void createPiecePrototypes () {

		MoveData.loadMoveData ();	// uses MoveData to create move objects
		PieceData.loadPieceData ();	// uses PieceData to create piece objects

	}


	void loadPiecePrefabs() {

		GameObject prefabs = GameObject.FindGameObjectWithTag ("Prefabs");	// find the prefabs 'folder'

		Transform pieces = prefabs.transform.Find ("Pieces");	// find the pieces folder within it

		pieces.gameObject.SetActive (true);		// set it active so we can iterate through children

		foreach (Transform child in pieces) {		// get the children of pieces (piece prefabs)

			string name = child.name.Replace ("pref_Track", ""); // calculate short piece name
	
			piecePrefabs.Add (name, child.gameObject);		// add this piece to the prefabs dictionary so we can grab it by name

		}

		pieces.gameObject.SetActive (false);	// reset the pieces folder to inactive so these objects don't show

	}


	// returns a list of valid pieces to be placed in a tile, going in a given direction.

	public List<Piece> getValidPieces (Tile tile, int rotation, Hole hole) {

		List<Piece> validPieces = new List<Piece> ();	// setup a new list to hold the pieces

		foreach (string key in piecePrototypes.Keys) {	// loop through the prototype pieces

			Piece p = piecePrototypes [key];	// link to this prototype

			if (p.canPlaceHere (tile, rotation, hole)) {		// call function that checks if a piece can be placed here
				validPieces.Add (p);	// if so, add it to the list
			}

		}

		return validPieces;

	}
		
	// Update is called once per frame
	void Update () {
		
	}


	public void placeDebugCube(Tile tile) {

		GameObject go = SimplePool.Spawn (debugCube, new Vector3 (tile.x + 0.5f, tile.z + 0.2f, tile.y), Quaternion.identity);
		// place a cube in the world to show this tile has been 'blocked off'
	}

	// place a piece gameObject in the game world.

	public void getPiecePrefab (Piece piece) {

		string lookup = piece.hole.skin + piece.name;	// calculate the string we'll need to look up the right piece with the right skin

		GameObject go = SimplePool.Spawn (piecePrefabs [lookup], new Vector3 (piece.tile.x, piece.tile.y, piece.tile.z), Quaternion.identity);
		go.name = lookup + " " + piece.tile.x + " - " + piece.tile.y + " - " + piece.tile.z;
		go.transform.SetParent(piece.hole.folder.transform);	// spawn the gameObject from pool, give better name and put in the folder for its hole

		go.transform.position = piece.getWorldPosition ();	// set the position of the piece in the game world
		go.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, piece.rotation, transform.eulerAngles.z);
				// rotate the piece according to the current direction of travel

		pieceToGameObjectMap.Add (piece, go);	// add piece to the map so we can get later if necessary
	}



}
