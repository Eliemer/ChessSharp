module Models

type Position = { X : int; Y : int }
type Color = Black | White
type Occupied = Empty | Ally | Enemy
type PieceType =
    | King
    | Queen
    | Rook
    | Knight
    | Bishop
    | Pawn

type Piece = {PieceType : PieceType; Color : Color; Position : Position}
type Board = Option<Piece> [,]