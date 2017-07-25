using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveData {



	public static void loadMoveData () {

		Move move;
		List<Vector2> tiles;

		// x, y, z, r

		tiles = new List<Vector2> ();
		move = new Move (0, 1, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);


		tiles = new List<Vector2> ();
		tiles.Add (new Vector2 (0, 1));
		move = new Move (0, 2, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		tiles.Add (new Vector2 (0, 1));
		tiles.Add (new Vector2 (0, 2));
		move = new Move (0, 3, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);


		tiles = new List<Vector2> ();
		tiles.Add (new Vector2 (0, 1));
		tiles.Add (new Vector2 (0, 2));
		tiles.Add (new Vector2 (1, 0));
		tiles.Add (new Vector2 (1, 1));
		tiles.Add (new Vector2 (1, 2));
		move = new Move (1, 3, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		tiles.Add (new Vector2 (0, 1));
		tiles.Add (new Vector2 (0, 2));
		tiles.Add (new Vector2 (0, 3));
		tiles.Add (new Vector2 (1, 0));
		tiles.Add (new Vector2 (1, 1));
		tiles.Add (new Vector2 (1, 2));
		tiles.Add (new Vector2 (1, 3));
		tiles.Add (new Vector2 (2, 0));
		tiles.Add (new Vector2 (2, 1));
		tiles.Add (new Vector2 (2, 2));
		tiles.Add (new Vector2 (2, 3));
		move = new Move (2, 4, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		tiles.Add (new Vector2 (0, 1));
		tiles.Add (new Vector2 (0, 2));
		tiles.Add (new Vector2 (-1, 0));
		tiles.Add (new Vector2 (-1, 1));
		tiles.Add (new Vector2 (-1, 2));
		move = new Move (-1, 3, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		tiles.Add (new Vector2 (0, 1));
		tiles.Add (new Vector2 (0, 2));
		tiles.Add (new Vector2 (0, 3));
		tiles.Add (new Vector2 (-1, 0));
		tiles.Add (new Vector2 (-1, 1));
		tiles.Add (new Vector2 (-1, 2));
		tiles.Add (new Vector2 (-1, 3));
		tiles.Add (new Vector2 (-2, 0));
		tiles.Add (new Vector2 (-2, 1));
		tiles.Add (new Vector2 (-2, 2));
		tiles.Add (new Vector2 (-2, 3));
		move = new Move (-2, 4, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		tiles.Add (new Vector2 (-1, 0));
		move = new Move (-1, 1, 0, -90, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);


		tiles = new List<Vector2> ();
		tiles.Add (new Vector2 (1, 0));
		move = new Move (1, 1, 0, 90, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		tiles.Add (new Vector2 (0, 1));
		tiles.Add (new Vector2 (1, 0));
		tiles.Add (new Vector2 (1, 1));
		move = new Move (1, 2, 0, 90, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		tiles.Add (new Vector2 (0, 1));
		tiles.Add (new Vector2 (0, 2));
		tiles.Add (new Vector2 (1, 0));
		tiles.Add (new Vector2 (1, 1));
		tiles.Add (new Vector2 (1, 2));
		tiles.Add (new Vector2 (2, 0));
		tiles.Add (new Vector2 (2, 1));
		tiles.Add (new Vector2 (2, 2));
		move = new Move (2, 3, 0, 90, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		tiles.Add (new Vector2 (0, 1));
		tiles.Add (new Vector2 (-1, 0));
		tiles.Add (new Vector2 (-1, 1));
		move = new Move (-1, 2, 0, -90, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		tiles.Add (new Vector2 (0, 1));
		tiles.Add (new Vector2 (0, 2));
		tiles.Add (new Vector2 (-1, 0));
		tiles.Add (new Vector2 (-1, 1));
		tiles.Add (new Vector2 (-1, 2));
		tiles.Add (new Vector2 (-2, 0));
		tiles.Add (new Vector2 (-2, 1));
		tiles.Add (new Vector2 (-2, 2));
		move = new Move (-2, 3, 0, -90, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		tiles.Add (new Vector2 (0, 1));
		move = new Move (0, 2, 1, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		tiles.Add (new Vector2 (0, 1));
		tiles.Add (new Vector2 (0, 2));
		move = new Move (0, 3, 1, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		tiles.Add (new Vector2 (0, 1));
		tiles.Add (new Vector2 (0, 2));
		tiles.Add (new Vector2 (0, 3));
		move = new Move (0, 4, 1, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		move = new Move (-2, -1, -1, 90, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		move = new Move (2, -1, -1, -90, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		move = new Move (-3, 1, -1, 180, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		move = new Move (3, 1, -1, 180, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles = new List<Vector2> ();
		move = new Move (0, 5, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

	}


}
