open Models
open Behaviours

let initBoard () : Board =
    let mutable board : Board = Array2D.init 8 8 (fun i j -> None)
    
    // White team
    // Pawns
    board.[1, *] <- [| for i=0 to 7 do Some {PieceType = Pawn; Color = White; Position = {X = 1; Y = i}} |]

    // Rooks
    board.[0, 0] <- Some {PieceType = Rook; Color = White; Position = {X = 0; Y = 0}}
    board.[0, 7] <- Some {PieceType = Rook; Color = White; Position = {X = 0; Y = 7}}

    // Knights
    board.[0, 1] <- Some {PieceType = Knight; Color = White; Position = {X = 0; Y = 1}}
    board.[0, 6] <- Some {PieceType = Knight; Color = White; Position = {X = 0; Y = 6}}

    // Bishops
    board.[0, 2] <- Some {PieceType = Bishop; Color = White; Position = {X = 0; Y = 2}}
    board.[0, 5] <- Some {PieceType = Bishop; Color = White; Position = {X = 0; Y = 5}}

    // King & Queen
    board.[0, 3] <- Some {PieceType = Queen; Color = White; Position = {X = 0; Y = 3}}
    board.[0, 4] <- Some {PieceType = King; Color = White; Position = {X = 0; Y = 4}}


    // Black team
    // Pawns
    board.[6, *] <- [| for i=0 to 7 do Some {PieceType = Pawn; Color = Black; Position = {X = 6; Y = i}} |]

    // Rooks
    board.[7, 0] <- Some {PieceType = Rook; Color = Black; Position = {X = 7; Y = 0}}
    board.[7, 7] <- Some {PieceType = Rook; Color = Black; Position = {X = 7; Y = 7}}

    // Knights
    board.[7, 1] <- Some {PieceType = Knight; Color = Black; Position = {X = 7; Y = 1}}
    board.[7, 6] <- Some {PieceType = Knight; Color = Black; Position = {X = 7; Y = 6}}

    // Bishops
    board.[7, 2] <- Some {PieceType = Bishop; Color = Black; Position = {X = 7; Y = 2}}
    board.[7, 5] <- Some {PieceType = Bishop; Color = Black; Position = {X = 7; Y = 5}}

    // King & Queen
    board.[7, 3] <- Some {PieceType = Queen; Color = Black; Position = {X = 7; Y = 3}}
    board.[7, 4] <- Some {PieceType = King; Color = Black; Position = {X = 7; Y = 4}}

    board

let printBoard (board : Board) : unit =
    ()

[<EntryPoint>]
let main argv =
    let mutable board : Board = initBoard()

    printfn "%A" board
    0