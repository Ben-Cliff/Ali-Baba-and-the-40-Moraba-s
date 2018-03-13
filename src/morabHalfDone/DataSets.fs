module DataSets

open System

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