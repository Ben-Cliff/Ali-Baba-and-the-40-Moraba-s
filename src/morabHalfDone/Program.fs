// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System

//Data Structures---------------------------------------------------------
type Position = { 
    x : int
    y : int }


type Mill = {
    PointA : Position
    PointB : Position
    PointC : Position

    Activ : bool
    Relodid : bool 
    } 

let rec consColorWrite =
    fun (msg : string) ->
        let head = msg.Chars 0
        let newMsg = msg.Substring(1)
        match head with
        | '1' ->
            System.Console.ForegroundColor<-System.ConsoleColor.Red
            System.Console.Write(head);
        | '9' ->
            System.Console.ForegroundColor<-System.ConsoleColor.Blue
            System.Console.Write(head);
        | '[' | ']' | '-' | '|' | '\\' | '/' | ',' ->
            System.Console.ForegroundColor<-System.ConsoleColor.DarkGray
            System.Console.Write(head);
        | a ->
            System.Console.ForegroundColor<-System.ConsoleColor.White
            System.Console.Write(head);
        match newMsg with
        | "" -> System.Console.WriteLine() // End line
        | _ -> consColorWrite newMsg

let whatBoardDraws =
    fun item ->
        match item with
        | 0 -> ' '
        | 1 -> '1'
        | 2 -> '9'

let drawBoard =
    fun (board: int list) ->
        let lin00 =         "\t  \t1,2,3       4       5,6,7"
        let lin01 = sprintf "\t[A]\t%c-----------%c-----------%c" (whatBoardDraws (board.Item 0)) (whatBoardDraws (board.Item 1)) (whatBoardDraws (board.Item 2))
        let lin02 =         "\t   \t|\          |          /|"
        let lin03 = sprintf "\t[B]\t| %c---------%c---------%c |" (whatBoardDraws (board.Item 3)) (whatBoardDraws (board.Item 4)) (whatBoardDraws (board.Item 5))
        let lin04 =         "\t   \t| |\        |        /| |"
        let lin05 = sprintf "\t[C]\t| | %c-------%c-------%c | |" (whatBoardDraws (board.Item 6)) (whatBoardDraws (board.Item 7)) (whatBoardDraws (board.Item 8))
        let lin06 =         "\t   \t| | |               | | |"
        let lin07 = sprintf "\t[D]\t%c-%c-%c               %c-%c-%c" (whatBoardDraws (board.Item 9)) (whatBoardDraws (board.Item 10)) (whatBoardDraws (board.Item 11)) (whatBoardDraws (board.Item 12)) (whatBoardDraws (board.Item 13)) (whatBoardDraws (board.Item 14))
        let lin08 =         "\t   \t| | |               | | |"
        let lin09 = sprintf "\t[E]\t| | %c-------%c-------%c | |" (whatBoardDraws (board.Item 15)) (whatBoardDraws (board.Item 16)) (whatBoardDraws (board.Item 17))
        let lin10 =         "\t   \t| |/        |        \| |"
        let lin11 = sprintf "\t[F]\t| %c---------%c---------%c |" (whatBoardDraws (board.Item 18)) (whatBoardDraws (board.Item 19)) (whatBoardDraws (board.Item 20))
        let lin12 =         "\t   \t|/          |          \|"
        let lin13 = sprintf "\t[G]\t%c-----------%c-----------%c" (whatBoardDraws (board.Item 21)) (whatBoardDraws (board.Item 22)) (whatBoardDraws (board.Item 23))
        let boundString = "\n\n" + lin00 + "\n\n" + lin01 + "\n" + lin02 + "\n" + lin03 + "\n" 
                                                  + lin04 + "\n" + lin05 + "\n" + lin06 + "\n"
                                                  + lin07 + "\n" + lin08 + "\n" + lin09 + "\n" 
                                                  + lin10 + "\n" + lin11 + "\n" + lin12 + "\n" 
                                                  + lin13 + "\n";
        consColorWrite boundString

let flatboard : int list =                     //flat co ordinate system used for operation. See ReadMe
   // [col0   ;  col1 ;   col2  ;  col3......
    [0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0]       // .[x co ord][y co ord]. 
  //[[r1;r2;r3];...]

  
let mills = //all possible mills                                                                                //////////////////////////////////////////////////////////////////////////////////
    let a = { PointA ={x= 0;y= 0} ; PointB = {x= 0;y= 8} ; PointC = {x= 0;y= 16} ; Activ = false ; Relodid = true} //verticals up-> down
    let b = { PointA ={x= 1;y= 0} ; PointB = {x= 1;y= 8} ; PointC = {x= 1;y= 16} ; Activ = false ; Relodid = true} // ''
    let c = { PointA ={x= 2;y= 0} ; PointB = {x= 2;y= 8} ; PointC = {x= 2;y= 16} ; Activ = false ; Relodid = true} // ''
    let d = { PointA ={x= 3;y= 0} ; PointB = {x= 3;y= 8} ; PointC = {x= 3;y= 16} ; Activ = false ; Relodid = true}
    let e = { PointA ={x= 4;y= 0} ; PointB = {x= 4;y= 8} ; PointC = {x= 4;y= 16} ; Activ = false ; Relodid = true}
    let f = { PointA ={x= 5;y= 0} ; PointB = {x= 5;y= 8} ; PointC = {x= 5;y= 16} ; Activ = false ; Relodid = true}
    let g = { PointA ={x= 6;y= 0} ; PointB = {x= 6;y= 8} ; PointC = {x= 6;y= 16} ; Activ = false ; Relodid = true}
    let h = { PointA ={x= 7;y= 0} ; PointB = {x= 7;y= 8} ; PointC = {x= 7;y= 16} ; Activ = false ; Relodid = true}
    
    let i = { PointA ={x= 0;y= 0} ; PointB = {x= 1;y= 0} ; PointC = {x= 2;y= 0} ; Activ = false ; Relodid = true} //Horizontal row Left -> right starting left corner 
    let j = { PointA ={x= 2;y= 0} ; PointB = {x= 3;y= 0} ; PointC = {x= 4;y= 0} ; Activ = false ; Relodid = true}
    let k = { PointA ={x= 4;y= 0} ; PointB = {x= 5;y= 0} ; PointC = {x= 6;y= 0} ; Activ = false ; Relodid = true}
    let l = { PointA ={x= 6;y= 0} ; PointB = {x= 7;y= 0} ; PointC = {x= 0;y= 0} ; Activ = false ; Relodid = true}  //Note! loop around     ( 0 ; 0)  
    
    let m = { PointA ={x= 0;y= 8} ; PointB = {x= 1;y= 8} ; PointC = {x= 2;y= 8} ; Activ = false ; Relodid = true} // horizontal second row Left -> right
    let n = { PointA ={x= 2;y= 8} ; PointB = {x= 3;y= 8} ; PointC = {x= 4;y= 8} ; Activ = false ; Relodid = true}
    let o = { PointA ={x= 4;y= 8} ; PointB = {x= 5;y= 8} ; PointC = {x= 6;y= 8} ; Activ = false ; Relodid = true}
    let p = { PointA ={x= 6;y= 8} ; PointB = {x= 7;y= 8} ; PointC = {x= 0;y= 8} ; Activ = false ; Relodid = true} //Note! loop around     ( 0 ; 0)  

    let q = { PointA ={x= 0;y= 16} ; PointB = {x= 1;y= 16} ; PointC = {x= 2;y= 16} ; Activ = false ; Relodid = true} // horizontal second row Left -> right
    let r = { PointA ={x= 2;y= 16} ; PointB = {x= 3;y= 16} ; PointC = {x= 4;y= 16} ; Activ = false ; Relodid = true}
    let s = { PointA ={x= 4;y= 16} ; PointB = {x= 5;y= 16} ; PointC = {x= 6;y= 16} ; Activ = false ; Relodid = true}
    let t = { PointA ={x= 6;y= 16} ; PointB = {x= 7;y= 16} ; PointC = {x= 0;y= 16} ; Activ = false ; Relodid = true} //Note! loop around     ( 0 ; 0)  
    [a;b;c;d;e;f;g;h;i;j;k;l;m;n;o;p;q;r;s;t]



//FUNCTION DEFINITIONS--------------------------------------------------

let mrbaToFlat (a : string) : int list =           //converts from morabaraba user co ordinates to flat co ordinates
    match a with
        |"A1" -> [0;0]            //  Xcoord , Ycoord
        |"B2" -> [0;8]
        |"C3" -> [0;16]
        |"A4" -> [1;0]
        |"B4" -> [1;8]
        |"C4" -> [1;16]
        |"A7" -> [2;0]
        |"B6" -> [2;8]
        |"C5" -> [2;16]
        |"D7" -> [3;0]
        |"D6" -> [3;8]
        |"D5" -> [3;16]
        |"G7" -> [4;0]
        |"F6" -> [4;8]
        |"E5" -> [4;16]
        |"G4" -> [5;0]
        |"F4" -> [5;8]
        |"E4" -> [5;16]
        |"G1" -> [6;0]
        |"F2" -> [6;8]
        |"E3" -> [6;16]
        |"D1" -> [7;0]
        |"D2" -> [7;8]
        |"D3" -> [7;16]
        |_ -> [9;9]

//---------------------------------------------------------------------------------
//The following functions are the functions passed into UPDATEBOARD. They determine how the board will be updated.

let insertcow (player: int) (coord: int) (board : int list) (index : int) (valu: int): int = //this function is passed into updateboard (custom List.mapi), operates on each element
    match (index = coord )with
    | true -> player //coord ofType in. (x+y)
    |_ -> valu

let removecow (player: int) (coord: int) (board : int list) (index : int) (valu: int): int = 
    match (index = coord) with
    | true -> 0 //coord ofType in. (x+y)
    |_ -> valu

//UPDATEBOARD below
let updateboard (f : int -> int -> int list -> int -> int -> int) (player: int) (coord: int) (board : int list) : int list =      //Similar to mapi, altered for game purposes
    let rec innerF (lst : int list) (inc : int) (len : int) (ans : int list): int list =    // inc used as length at first call, and list incerment in recursion 
        match (inc - len) with
        |0 -> ans
        |a -> innerF lst (inc+1) len (List.append ans [(f player coord lst inc lst.[(inc)])])
    innerF board 0 board.Length []
//---------------------------------------------------------------------------------
//MAIN FUNCTIONS: PLACE, MOVE FLY

let rec interaction (player :int ) (board : int list) (sentence : string):string =       //takes in input and checks if it exists (see isoccupied for position che)
    System.Console.Clear()
    drawBoard board
    let msg = sprintf "%A's  turn: type the Y value of the cell that you want to %s. 
             Only accepts letters A ; B ; C ; D; E ; F ; G" player sentence // sentence = "play into" for place state as appose to " mve from " alterative for move state
    consColorWrite msg
    let i = (Convert.ToString (System.Console.ReadKey true).KeyChar).ToUpper()
    match i with 
    | "A" | "B" | "C" | "D" | "E" | "F" | "G" ->
        let d = string i                                //saves Y value into d
        printfn "Type the X coordinate of the position that you want to %s.
                 EG '3' (Between 1 - 7) " sentence // sentence = "play into" for place state as appose to " mve from " alterative for move state
        let n = (System.Console.ReadKey true).KeyChar
        match n with
        | '1' | '2' | '3' | '4' | '5' | '6' | '7' ->
            match  mrbaToFlat (d + string(n))    with
            | [9;9]-> interaction player board sentence    //potential change for options, watch this space failinput                                                            
            | _ -> (d + string(n) )             //final return case -> Saves value into n and smushes input into string EG "A
        | _ -> interaction player board sentence//invalid input, try again silly hooman      
    | _ -> interaction player board sentence//invalid input, try again silly hooman 
   



let rec place (mills : Mill list) (player : int) (cowsleft : int) (board : int list) (ismill : Mill list -> int list -> int list -> int -> bool) : int list=        //SKELETON //cowsleft should be 24 when first called
    match cowsleft with
    |0 -> board
    |_ ->                                                   
        let spot = interaction player board "play into"                     //accepted input
        let spott = match (mrbaToFlat spot) with             //Testing if use input is valid
                    |[9;9] -> [9;9] ///TEMP. fail case goes here. MUST CHANGE $$$$$$$$$$$$$$$$$$$$$$$$
                    |_ -> mrbaToFlat spot

        let board = updateboard insertcow player (spott.[0] + spott.[1]) (*<- this is x+y. see ReadMe*) board
        //Functions in place-----------------------------


        let shoot (point : int) (victim: int) (board: int list): int list =   //Still need to make sure the victim cow is not in a mill
            match (board.[point] = victim) with
            |true -> updateboard removecow victim point board
            |_ -> board //INCOMPLETE: THIS CASE MUST ASK FOR ANOTHER CO ORD TO SHOOT, ONE THAT IS VALID

        let otherplayer (player : int) : int = //Returns the opposite player
            match player with 
            |1 -> 2
            |_ -> 1
        //------------------------------------------------
        (*let board =                                         //checks if cow is in a mill, shoots if it is
            match (ismill mills board (spott) player) with
            |true -> shoot (spott.[0] + spott.[1]) (otherplayer player) board
            |false -> board *) 
        printf"%A \n"board
        match player with 
        |1 -> place mills 2 (cowsleft-1) (board) ismill 
        |_ -> place mills 1 (cowsleft-1) (board) ismill
    
    //take coordinate of just placed piece from int list
// recursive innerf looks at mill list, compare singulare coordinate with mills 
//          --> checks specific mill(s) that would be involved in list
//              --> capture neccessary points from potential mill
//              --> Compare with current board stat
//              YAY / NAY *************************************************loading to be done

//  MOVE FUNCTION :: in progress version allows 20 moves, as cows cannit be shot yet. hence movesleft parameter
let rec move (movesleft : int) (mills : Mill list) (player : int) (board : int list) (ismill : Mill list -> int list -> int list -> int -> bool) : int list =        //SKELETON 
    
    let froms = interaction player board "move from"//take in user input
    let movetos = interaction player board "move to"//take in user input
    let (from : int list) = mrbaToFlat froms
    let (moveto : int list) = mrbaToFlat movetos
    (*let allgood = match oneaway from moveto with
                |true -> updateboard insertcow player moveto (updateboard removecow player from board)    
                //board is updated to remove cow. this result is passed into the next update which adds the cow to its new position.           
                |_ -> move*) 

    (*let oneaway (from: int list) (moveto : int list) : bool = //checks if move position is 1 away
        match (moveto.[0] = (from.[0] + 1)) || (moveto.[0] = (from.[0] - 1)) with //x value differs by 1        
        |true -> match (moveto.[1] = (from.[1] + 1)) || (moveto.[1] = (from.[1] - 1)) with //y value differs by 1 
                 |true -> true
                 |_ -> false
        |_ -> false*)
        
    let board = updateboard insertcow player (moveto.[0] + moveto.[1]) (updateboard removecow player (from.[0] + from.[1]) board)    

    let shoot (point : int) (victim: int) (board: int list): int list =   //Still need to make sure the victim cow is not in a mill
        match (board.[point] = victim) with
        |true -> updateboard removecow victim point board
        |_ -> board //INCOMPLETE: THIS CASE MUST ASK FOR ANOTHER CO ORD TO SHOOT, ONE THAT IS VALID

    let otherplayer (player : int) : int = //Returns the opposite player
        match player with 
        |1 -> 2
        |_ -> 1
        //------------------------------------------------
        (*let board =                                         //checks if cow is in a mill, shoots if it is
            match (ismill mills board (moveto) player) with
            |true -> shoot (spott.[0] + spott.[1]) (otherplayer player) board
            |false -> board*)
    printf"%A \n"board
    match movesleft with
    |0 -> board
    |_ -> match player with 
          |1 -> move (movesleft-1) mills 2 (board) ismill 
          |_ -> move (movesleft-1) mills 1 (board) ismill
    
            




//LESSER FUNCTIONS. MILL CHECKS, SHOOTING

let shoot (point : int) (victim: int) (board: int list): int list =   //Still need to make sure the victim cow is not in a mill
    match (board.[point] = victim) with
        |true -> updateboard removecow victim point board
        |_ -> board //INCOMPLETE: THIS CASE MUST ASK FOR ANOTHER CO ORD TO SHOOT, ONE THAT IS VALID
         
let ismill (mills : Mill list) (board : int list) (spott : int list) (player : int): bool =                    //function checks which possible mills a co-ord can be a part of, and if they are full (call to millfull)       
    let rec innerF (mills : Mill list) (board : int list) (spott: int list) (inc : int) (player : int) : bool =

        let millfull (mil : Mill) (player : int) (board : int list): bool = 
            match ( (board.[mil.PointA.x + mil.PointA.y] = player) && (board.[mil.PointB.x + mil.PointB.y] = player) && (board.[mil.PointB.x + mil.PointB.y] = player)) with
                |true -> true
                |_ -> false
        let xandy (mil : Mill) (abc : string) : int list =      //generates x and y list for specofied position in mill
            match abc with
            |"A" -> [mil.PointA.x ; mil.PointA.y]
            |"B" -> [mil.PointB.x ; mil.PointB.y]
            |"C" -> [mil.PointC.x ; mil.PointA.y]
            |_ -> [0;0]

        match inc with
        |20 -> false                    //applies to each mill in list. i.e 20 iterations
        |_  -> match ((xandy mills.[inc] "A" = spott) || (xandy mills.[inc] "B" = spott) || (xandy mills.[inc] "C" = spott) ) with      //comepares the spot [x;y] with          
               |true -> millfull mills.[inc] player board
               |_ -> innerF mills board spott (inc+1) player 
    innerF mills board spott 0 player
    //NOTE FACK: certain positions hold up to three mills, need to carry on recursion

let (placedboard : int list) = [0]
[<EntryPoint>]
let main argv = 
    move 20 mills 1 (place mills 1 24 flatboard ismill) ismill
    0 // return an integer exit code
