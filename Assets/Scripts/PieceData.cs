using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PieceData {


	public static void addMove(Piece proto, string move) {

		//Debug.Log ("LOOK FOR: " + move);

		if (PieceController.Instance.moveNameMap.ContainsKey(move)) {
			proto.moves.Add (PieceController.Instance.moveNameMap[move]);
			return;
		}
			
		//Debug.Log(move + " not found");

		

	}

	public static void loadPieceData () {

		Piece proto;

		//                    NAME,      X, Y, DF, FQ, XOFF, 2SPLIT, 3SPLIT

		proto = new Piece ("Start", 1, 1, 1, 5, 0, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, 0, 0, 0));

		proto = new Piece ("Straight_01", 1, 1, 1, 5, 0, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, 0, 0, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 1 UD 0 RO 0");

		proto = new Piece ("Straight_02", 1, 2, 1, 4, 0, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, 0, 1, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 2 UD 0 RO 0");

		proto = new Piece ("Straight_03", 1, 3, 1, 3, 0, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, 0, 2, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 3 UD 0 RO 0");

		proto = new Piece ("Zigzag_01", 2, 3, 2, 2, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, 1, 2, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 1 FB 3 UD 0 RO 0");

		proto = new Piece ("Zigzag_02", 2, 4, 3, 2, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, 1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 2 FB 4 UD 0 RO 0");

		proto = new Piece ("Zigzag_03", 2, 3, 2, 2, -1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 2, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR -1 FB 3 UD 0 RO 0");

		proto = new Piece ("Zigzag_04", 2, 4, 3, 2, -1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR -2 FB 4 UD 0 RO 0");

		proto = new Piece ("Zigzag_05", 1, 3, 2, 2, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, 1, 2, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 1 FB 3 UD 0 RO 0");

		proto = new Piece ("Zigzag_06", 2, 3, 2, 2, -1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 2, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR -1 FB 3 UD 0 RO 0");

		proto = new Piece ("Zigzag_07", 2, 4, 2, 2, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, 1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 2 FB 4 UD 0 RO 0");

		proto = new Piece ("Zigzag_08", 2, 4, 2, 2, -1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR -2 FB 4 UD 0 RO 0");

		proto = new Piece ("Curve_01", 1, 2, 4, 3, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 1 FB 2 UD 0 RO 90");

		proto = new Piece ("Curve_02", 1, 2, 3, 3, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 1 FB 2 UD 0 RO 90");

		proto = new Piece ("Curve_03", 1, 2, 2, 3, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 1 FB 2 UD 0 RO 90");

		proto = new Piece ("Curve_04", 2, 2, 2, 3, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 2 FB 3 UD 0 RO 90");

		proto = new Piece ("Curve_05", -1, 2, 4, 3, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR -1 FB 2 UD 0 RO -90");

		proto = new Piece ("Curve_06", -1, 2, 3, 3, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR -1 FB 2 UD 0 RO -90");

		proto = new Piece ("Curve_07", 1, -2, 2, 3, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR -1 FB 2 UD 0 RO -90");

		proto = new Piece ("Curve_08", -2, 2, 2, 3, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR -2 FB 3 UD 0 RO -90");

		proto = new Piece ("Hill_01", 0, 1, 3, 2, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 1 UD 0 RO 0");

		proto = new Piece ("Hill_02", 0, 2, 3, 2, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 2 UD 0 RO 0");

		proto = new Piece ("Hill_03", 0, 3, 3, 2, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 3 UD 0 RO 0");

		proto = new Piece ("Hill_04", 0, 2, 3, 2, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 2 UD 0 RO 0");

		proto = new Piece ("Hill_05", 0, 3, 3, 2, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 3 UD 0 RO 0");

		proto = new Piece ("Hill_06", 0, 5, 3, 2, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 5 UD 0 RO 0");

		proto = new Piece ("HillCurve_01", 1, 2, 3, 2, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 1 FB 2 UD 0 RO 90");

		proto = new Piece ("HillCurve_02", -1, 2, 3, 2, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR -1 FB 2 UD 0 RO 90");

		proto = new Piece ("HillCurve_03", -1, 2, 3, 2, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR -1 FB 2 UD 0 RO -90");

		proto = new Piece ("HillCurve_04", -2, 3, 3, 2, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR -2 FB 3 UD 0 RO -90");


		proto = new Piece ("Elevation_01", 0, 2, 5, 1, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 2 UD 1 RO 0");

		proto = new Piece ("Elevation_02", 0, 2, 5, 1, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 4 UD 1 RO 0");

		proto = new Piece ("Elevation_03", 0, 2, 4, 1, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 2 UD 1 RO 0");

		proto = new Piece ("Elevation_04", 0, 2, 3, 1, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 3 UD 1 RO 0");

		proto = new Piece ("ElevationCurve_01", 0, 2, 3, 1, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR -2 FB -1 UD -1 RO 90");

		proto = new Piece ("ElevationCurve_02", 0, 2, 3, 1, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 2 FB -1 UD -1 RO -90");


		proto = new Piece ("ElevationCurve_03", 0, 2, 3, 1, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR -3 FB 1 UD -1 RO 180");

		proto = new Piece ("ElevationCurve_04", 0, 2, 3, 1, 1, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, -1, 3, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 3 FB 1 UD -1 RO 180");

		proto = new Piece ("Ramp_01", 1, 1, 1, 1, 0, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, 0, 0, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 1 UD 0 RO 0");

		proto = new Piece ("Ramp_02", 1, 2, 2, 1, 0, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, 0, 1, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 2 UD 0 RO 0");

		proto = new Piece ("Ramp_03", 1, 3, 3, 1, 0, false, false);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		proto.exits.Add (new Exit (direction.North, proto, 0, 2, 0));
		proto.exits.Add (new Exit (direction.South, proto, 0, 0, 0));
		addMove (proto, "LR 0 FB 3 UD 0 RO 0");



	}



}
