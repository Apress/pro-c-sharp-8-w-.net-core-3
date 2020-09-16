// Learn more about F# at http://fsharp.org

// Calc.fs
open System

module Calc = 
    let add x y =
        x + y

[<EntryPoint>]
let main argv =
    let ans = Calc.add 10 84
    printfn "10 + 84 is %d" ans
    Console.ReadLine()
    0 
