module Behaviours

open Models

let getPositionOccupant (pos : Position) (piece : Piece) (board : Board) : Occupied =
    match board.[pos.X, pos.Y] with
        | None -> Empty
        | Some piece' -> if piece.Color = piece'.Color then Ally else Enemy

let getPositionOccupant' (pos : Position) (color : Color) (board : Board) : Occupied =
    match board.[pos.X, pos.Y] with
        | None -> Empty
        | Some piece -> if piece.Color = color then Ally else Enemy

let isWithinBoard (piece : Piece) : bool =
    let x = piece.Position.X
    let y = piece.Position.Y

    x >= 0 && x < 8 && y >= 0 && y < 8

let isWithinBoard' (pos : Position) : bool =
    pos.X >= 0 && pos.Y >= 0 && pos.X < 8 && pos.Y < 8

let canMoveTo (color : Color) (board : Board) (pos : Position) : bool =
    match getPositionOccupant' pos color board with
        | Ally -> false
        | _ -> true

let generateAllMoves (piece : Piece) : seq<Position> =
    match piece.PieceType with
        | King  ->
            let (x, y) = (piece.Position.X , piece.Position.Y)
            seq { for row in -1 .. 1 do
                    for col in -1 .. 1 do
                       { X = x + row; Y = y + col }}

        | Queen -> Seq.empty
        | Rook -> Seq.empty
        | Knight -> Seq.empty
        | Bishop -> Seq.empty
        | Pawn -> Seq.empty

let generateMoves (piece: Piece) (board : Board) : seq<Position> =
    generateAllMoves piece
    |> Seq.filter isWithinBoard'
    |> Seq.filter (canMoveTo piece.Color board)

let movePiece (piece : Piece) (pos : Position) (board : Board) : (Piece * Board) =
    board.[piece.Position.X, piece.Position.Y] <- None
    board.[pos.X, pos.Y] <- Some piece

    ({piece with Position = {X = pos.X; Y = pos.Y}}, board)