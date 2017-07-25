using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PieceController : MonoBehaviourSingleton<PieceController> { 


	public Dictionary<string, Piece> piecePrototypes;
	public Dictionary<Piece, GameObject> pieceToGameObjectMap;
	public Dictionary<string, GameObject> piecePrefabs;
	public List <Move> moves;
	public Dictionary <string, Move> moveNameMap;

	// Use this for initialization
	void Start () {

		createPiecePrototypes ();
		loadPiecePrefabs ();

	
	}



	public List<Piece> getValidPieces (Tile tile, direction dir, Hole hole) {

		List<Piece> validPieces = new List<Piece> ();

		foreach (string key in piecePrototypes.Keys) {

			Piece p = piecePrototypes [key];

			if (p.canPlaceHere (tile, dir, hole)) {

				validPieces.Add (p);
				Debug.Log ("OK: " + p.name + " " + p.moves.Count);

			}

		}

		return validPieces;
	

	}

	void createPiecePrototypes () {

		moveNameMap = new Dictionary<string, Move> ();
		moves = new List<Move> ();
		piecePrefabs = new Dictionary<string, GameObject> ();
		piecePrototypes = new Dictionary<string, Piece> ();

		MoveData.loadMoveData ();
		PieceData.loadPieceData ();


	}


	// Update is called once per frame
	void Update () {
		
	}


	void loadPiecePrefabs() {


		GameObject prefabs = GameObject.FindGameObjectWithTag ("Prefabs");
	
		Transform pieces = prefabs.transform.Find ("Pieces");

		pieces.gameObject.SetActive (true);

		foreach (Transform child in pieces) {
			
			string name = child.name;

			name = name.Replace ("pref_Track", "");
			//Debug.Log (name);

			piecePrefabs.Add (name, child.gameObject);


		}

		pieces.gameObject.SetActive (false);


	}


	public void getPiecePrefab (Piece piece) {

		string lookup = piece.hole.skin + piece.name;

		GameObject go = SimplePool.Spawn (piecePrefabs [lookup], new Vector3 (piece.tile.x, piece.tile.y, piece.tile.z), Quaternion.identity);
		go.name = lookup + " " + piece.tile.x + " - " + piece.tile.y + " - " + piece.tile.z;
		go.transform.SetParent(piece.hole.folder.transform);

		go.transform.position = piece.getWorldPosition ();
		go.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, piece.rotation, transform.eulerAngles.z);
	}



}
